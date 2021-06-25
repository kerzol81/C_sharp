using System;

namespace GPS_transformer_CLI
{
    class EOV
    {
        #region Properties
        public double eovX { get; set; }
        public double eovY { get; set; }
        public double longitude { get; set; }
        public double latitude { get; set; }
        #endregion

        #region Constructor
        public EOV(double eovx, double eovy)
        {

            eovX = eovx;
            eovY = eovy;
            EOV_to_GPS84();
        }
        #endregion
        double rad(double x)
        {
            return (x / 180.0 * Math.PI);
        }
        double deg(double x)
        {
            return (x / Math.PI * 180.0);
        }
        private void EOV_to_GPS84()
        {
            #region vars
            double a1 = 6378160, b1 = 6356774.52, a2 = 6378137, b2 = 6356752.31;
            double dX = 52.684, dY = -71.194, dZ = -13.975, eX = 0.312, eY = 0.1063, eZ = 0.3729, k = 1.0191e-6;
            double FI2, LA2, st, ct, teta, P, ev2, e22, f2, Zv, Yv, Xv;
            double h = 0; // height
            double Z, Y, X, N, e2, f, fi, la;

            double C1 = 1.0007197049;
            double E1 = rad(19.048571778);

            double G1 = rad(47.1);

            double H1 = 6379296.419;

            double I1 = 47.0 + 7.0 / 60.0 + 20.0578 / 3600.0;
            double J1 = rad(I1);

            double K1 = eovX - 200000;
            double L1 = eovY - 650000;

            double M1 = 2.0 * (Math.Atan(Math.Exp(K1 / H1)) - Math.PI / 4.0);
            double N1 = L1 / H1;

            double O1 = 47 + 1.0 / 6.0;
            double P1 = Math.Asin(Math.Cos(G1) * Math.Sin(M1) + Math.Sin(G1) * Math.Cos(M1) * Math.Cos(N1));

            double Q1 = Math.Asin(Math.Sin(N1) * Math.Cos(M1) / Math.Cos(P1));

            //R1
            double T1 = rad(O1);

            double U1 = 6378160;
            double V1 = 6356774.516;

            double W1 = (U1 * U1 - V1 * V1) * Math.Cos(T1) * Math.Cos(T1) / V1 / V1;
            double X1 = 180 * 3600 / Math.PI;

            double Y1 = Math.Sqrt(1.0 + W1);
            double Z1 = 1.5 * W1 * Math.Tan(T1) / X1;

            double AA1 = 0.5 * W1 * (-1.0 + Math.Tan(T1) * Math.Tan(T1) - W1 + 5 * W1 * Math.Tan(T1)) / Y1 / X1 / X1;
            double S1 = (P1 - J1) * X1;
            #endregion

            fi = (T1 + S1 * Y1 / X1 - S1 * S1 * Z1 / X1 + S1 * S1 * S1 * AA1 / X1);
            la = (E1 + Q1 / C1);

            f = (a1 - b1) / a1;
            e2 = 2 * f - f * f;

            N = a1 / (Math.Sqrt(1 - e2 * Math.Sin(fi) * Math.Sin(fi)));
            X = (N + h) * Math.Cos(fi) * Math.Cos(la);

            Y = (N + h) * Math.Cos(fi) * Math.Sin(la);
            Z = (N * (1 - e2) + h) * Math.Sin(fi);

            Xv = dX + (1 + k) * (X + rad(eZ / 3600) * Y - rad(eY / 3600) * Z);
            Yv = dY + (1 + k) * (-X * rad(eZ / 3600) + Y + Z * rad(eX / 3600));
            Zv = dZ + (1 + k) * (X * rad(eY / 3600) - Y * rad(eX / 3600) + Z);

            f2 = (a2 - b2) / a2;
            e22 = 2 * f2 - f2 * f2;
            ev2 = (a2 * a2 - b2 * b2) / b2 / b2;

            P = Math.Sqrt(Xv * Xv + Yv * Yv);
            teta = Math.Atan2(Zv * a2, P * b2);

            ct = Math.Cos(teta);
            st = Math.Sin(teta);
            FI2 = Math.Atan2(Zv + ev2 * b2 * st * st * st, P - e22 * a2 * ct * ct * ct);
            LA2 = Math.Atan2(Yv, Xv);
            longitude = deg(FI2);
            latitude = deg(LA2);
            longitude = Math.Round(longitude, 6);
            latitude = Math.Round(latitude, 6);
        }

        
        public void ConsoleView()
        {
            Console.WriteLine($"EovX: {eovX}\tLon: {longitude}\nEovY: {eovY}\tLat: {latitude}");
        }
    }
}
