using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

namespace M3RelaySim
{
    class Relay
    {
        private Thread _Thread;
        private volatile Boolean _KeepWorking;
        private Log _log;
        private Random random = new Random();

        public static int riderCounter = 0;

        public bool running = false;
        public string ipAddress = "";
        public UInt16 ipPort;
        public bool uuidLong, rpmLong, hrLong, kcalSend, clockSend, rssiSend;

        public List<Rider> riders = new List<Rider>();

        public Relay(Log log)
        {
            _log = log;
        }

        public void start(int numRiders)
        {
            riders.Clear();
            _Thread = new Thread(worker);
            _KeepWorking = running = true;
            for (int x = 0; x < numRiders; x++)
            {
                riders.Add(new Rider(random, x));
            }
            _Thread.Start();
        }

        public void stop()
        {
            _KeepWorking = running = false;
        }

        private void worker()
        {
            int counter = 0;
            Stopwatch runTime;
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(ipAddress), ipPort);
            socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);
            while (_KeepWorking)
            {
                runTime = Stopwatch.StartNew();
                _log.add("TX Block " + counter++, true);
                foreach (Rider rider in riders)
                {
                    rider.cycle();
                    _log.add(rider.getStats());
                }
                broadcast(socket, ipEndPoint);
                runTime.Stop();
                Thread.Sleep(Convert.ToUInt16(2000 - runTime.ElapsedMilliseconds));
            }
            socket.Close();
        }

        private void broadcast(Socket socket, IPEndPoint ipEndPoint)
        {
            List<byte> data = new List<byte>();
            data.Add(getConfig());
            foreach (Rider rider in riders)
                addRider(rider, data);
            socket.SendTo(data.ToArray(), ipEndPoint);
        }

        private byte getConfig()
        {
            byte configFlags = 0;
            if (uuidLong) configFlags = Convert.ToByte(configFlags | 1);
            if (rpmLong) configFlags = Convert.ToByte(configFlags | 2);
            if (hrLong) configFlags = Convert.ToByte(configFlags | 4);
            if (kcalSend) configFlags = Convert.ToByte(configFlags | 8);
            if (clockSend) configFlags = Convert.ToByte(configFlags | 16);
            if (rssiSend) configFlags = Convert.ToByte(configFlags | 32);
            return configFlags;
        }

        private void addRider(Rider rider, List<byte> data)
        {
            // Add first 3 bytes
            data.Add(rider.uuid[5]);
            data.Add(rider.uuid[4]);
            data.Add(rider.uuid[3]);
            if (uuidLong)
            {
                data.Add(rider.uuid[2]);
                data.Add(rider.uuid[1]);
                data.Add(rider.uuid[0]);
            }

            if (rpmLong)
                add_2_byte(rider.rpm, data);
            else
                add_1_byte(Convert.ToUInt16(rider.rpm / 10.0), data);

            if (hrLong)
                add_2_byte(rider.hr, data);
            else
                add_1_byte(Convert.ToUInt16(rider.hr / 10.0), data);

            add_2_byte(rider.power, data);

            if (kcalSend)
                add_2_byte(rider.kcal, data);

            if (clockSend)
                add_2_byte(rider.clock, data);

            if (rssiSend)
                data.Add(Convert.ToByte(rider.rssi & 0xFF));

        }

        private void add_1_byte(UInt16 data, List<byte> list)
        {
            list.Add(Convert.ToByte(data & 0xFF));
        }

        private void add_2_byte(UInt16 data, List<byte> list)
        {
            list.Add(Convert.ToByte(data & 0xFF));
            list.Add(Convert.ToByte((data >> 8) & 0xFF));
        }

    }

    class Rider
    {
        public UInt16 rpm, hr, power, kcal, clock;
        public Int16 rssi = -50;
        public byte[] uuid = new byte[6];

        private Random random;
        private int age, maxHR, gear, refresh = 2;
        private double cal;

        public Rider(Random parentRandom, int x)
        {
            random = parentRandom;
            age = random.Next(20, 55);
            maxHR = (2200 - (age * 10));
            hr = Convert.ToUInt16(random.Next(Convert.ToUInt16(maxHR * 0.4), Convert.ToUInt16(maxHR * 0.9)));
            rpm = Convert.ToUInt16(1100 * hr / maxHR);
            gear = random.Next(1, 24);
            power = getPower();
            cal = random.Next(0, 50000);
            kcal = calToKcal();
            clock = Convert.ToUInt16(random.Next(0, 300));
            generateUUID(x);
        }

        private UInt16 getPower()
        {
            return Convert.ToUInt16((gear / 64.0) * rpm);
        }

        private void generateUUID(int y)
        {
            for (int x = 0; x < 6; x++)
            {
                uuid[x] = Convert.ToByte(y + 1);
            }
             Relay.riderCounter++;
        }

        private string getUuidString()
        {
            string uuidString = "";
            int count = 0;
            foreach (Byte segment in uuid)
            {
                uuidString += string.Format("{0:X2}", segment);
                if (count++ < 5)
                    uuidString += ":";
            }
            return uuidString;
        }

        public void cycle()
        {
            int effort = effortPredictor();
            if (effort == 1)
            {
                if (gear < 24)
                    gear++;
                if (rpm < 1100)
                    rpm += Convert.ToUInt16(random.Next(0, 100));
                hr += Convert.ToUInt16(random.Next(10, 30));
            }
            if (effort == -1)
            {
                if (gear > 2)
                    gear--;
                if (rpm > 400)
                    rpm -= Convert.ToUInt16(random.Next(0, 100));
                hr -= Convert.ToUInt16(random.Next(10, 30));
            }
            power = getPower();
            cal += (power / 4.187) * 4 * refresh;
            kcal = Convert.ToUInt16(cal / 1000);
            clock += Convert.ToUInt16(refresh);
            if (random.Next(0, 10) > 5)
            {
                if (rssi < -19)
                    rssi++;
            }
            else
            {
                if (rssi > -60)
                    rssi--;
            }
        }

        private UInt16 calToKcal()
        {
            return Convert.ToUInt16(cal / 1000);
        }

        public int effortPredictor()
        {
            int effort = random.Next(0, 100);
            int hrRange = Convert.ToInt32((hr / maxHR) * 100);

            if (hrRange <= 50)
            {
                if (effort >= 90) return 1;
                return 0;
            }
            if (hrRange <= 60)
            {
                if (effort >= 75) return 1;
                if (effort >= 20) return 0;
                return -1;
            }
            if (hrRange <= 80)
            {
                if (effort >= 60) return 0;
                if (effort >= 20) return 1;
                return -1;
            }
            if (hrRange <= 90)
            {
                if (effort >= 95) return -1;
                if (effort >= 5) return 0;
                return 1;
            }
            return -1;
        }

        public string getStats()
        {
            return string.Format("RPM: {0,5:0.0} HR: {1,5:0.0} POWER: {2,4:} KCAL: {3,4:} CLOCK: {4,5:} UUID: {5} RSSI: {6,3}dBm", rpm / 10.0, hr / 10.0, power, kcal, clock, getUuidString(), rssi);
        }
    }
}
