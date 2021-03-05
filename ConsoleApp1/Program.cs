using System;
using System.Numerics;


namespace VectorAngle
{
    class Program
    {
        //ラジアンを度数に変換
        private static double DegFromRad(double v) => v * (180 / Math.PI);
        static void Main(string[] args)
        {
            int usingVector = 0;
            //Help
            if (args.Length == 0)
            {
                Console.WriteLine("using: vectorangle(.exe)  X1f Y1f Z1f X2f Y2f Z3f ");
                Environment.Exit(0);
            }
            else if (args.Length == 3 || args.Length == 6)
            {
                //Console.WriteLine($"Got {args.Length} arguments.");
                usingVector = args.Length / 3;
            }
            else
            {
                Console.WriteLine("E: Not enough arguments!");
                Environment.Exit(0);
            }

            //入力受け取り
            Vector3 baseVec = new Vector3(0, 0, 0);
            Vector3 angledVec = new Vector3(0, 0, 0);
            Vector3 axisX = new Vector3(1, 0, 0);
            Vector3 axisZ = new Vector3(0, 0, 1);
            try
            {

                baseVec.X = float.Parse(args[0]);
                baseVec.Y = float.Parse(args[1]);
                baseVec.Z = float.Parse(args[2]);
                if (usingVector == 2)
                {
                    angledVec.X = float.Parse(args[3]);
                    angledVec.Y = float.Parse(args[4]);
                    angledVec.Z = float.Parse(args[5]);
                }

            }
            catch
            {
                Console.WriteLine("E: Couldn't parse arguments!( not float? )");
                Environment.Exit(1);
            }

            Console.WriteLine($"IN\t\t baseVec{baseVec}, angledVec{angledVec}");

            //ベクトルの正規化
            baseVec = Vector3.Normalize(baseVec);
            angledVec = Vector3.Normalize(angledVec);
            Console.WriteLine($"NORM\t\t baseVec{baseVec}, angledVec{angledVec}");

            //なす角の算出
            float dotInputVsInput = Vector3.Dot(baseVec, angledVec);
            double angleInputVsInput = DegFromRad( Math.Acos(dotInputVsInput));
            float dotXVsInput = Vector3.Dot(axisX, baseVec);
            double angleXVsInput = DegFromRad( Math.Acos(dotXVsInput));
            float dotZVsInput = Vector3.Dot(axisZ, baseVec);
            double angleZVsInput = DegFromRad( Math.Acos(dotZVsInput));
            if(usingVector == 1)
            {
                Console.WriteLine($"Degree(VS. X)\t{angleXVsInput}");
                Console.WriteLine($"Degree(VS. Z)\t{angleZVsInput}");
            }else if(usingVector == 2)
            {
                Console.WriteLine($"Degree(between 2 inputs)\t{angleInputVsInput}");
            }


        }
    }
}
