using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIV_netBot
{
    class MathEx
    {
        // Number pi
        public const double PI = 3.14159265358979;
        // PI / 2 OR 90 deg
        public const double PI_2 = 1.5707963267949;
        // PI / 4 OR 45 deg
        public const double PI_4 = 0.785398163397448;
        // PI / 8 OR 22.5 deg
        public const double PI_8 = 0.392699081698724;
        // PI / 16 OR 11.25 deg
        public const double PI_16 = 0.196349540849362;
        // 2 * PI OR 180 deg
        public const double TWO_PI = 6.28318530717959;
        // 3 * PI_2 OR 270 deg
        public const double THREE_PI_2 = 4.71238898038469;
        // Number e
        public const double E = 2.71828182845905;
        // ln(10)
        public const double LN10 = 2.30258509299405;
        // ln(2)
        public const double LN2 = 0.693147180559945;
        // logB10(e)
        public const double LOG10E = 0.434294481903252;
        // logB2(e)
        public const double LOG2E = 1.44269504088896;
        // sqrt( 1 / 2 )
        public const double SQRT1_2 = 0.707106781186548;
        // sqrt( 2 )
        public const double SQRT2 = 1.4142135623731;
        // PI / 180
        public const double DEG_TO_RAD = 0.0174532925199433;
        //  180.0 / PI
        public const double RAD_TO_DEG = 57.2957795130823;

        // 2^16
        public const int B_16 = 65536;
        // 2^31
        public const long B_31 = 2147483648L;
        // 2^32
        public const long B_32 = 4294967296L;
        // 2^48
        public const long B_48 = 281474976710656L;
        // 2^53 !!NOTE!! largest accurate double floating point whole value
        public const long B_53 = 9007199254740992L;
        // 2^63
        public const ulong B_63 = 9223372036854775808;
        //18446744073709551615 or 2^64 - 1 or ULong.MaxValue...
        public const ulong B_64_m1 = ulong.MaxValue;

        //  1.0/3.0
        public const double ONE_THIRD = 0.333333333333333;
        //  2.0/3.0
        public const double TWO_THIRDS = 0.666666666666667;
        //  1.0/6.0
        public const double ONE_SIXTH = 0.166666666666667;

        // COS( PI / 3 )
        public const double COS_PI_3 = 0.866025403784439;
        //  SIN( 2*PI/3 )
        public const double SIN_2PI_3 = 0.03654595;
        // 4*(Math.sqrt(2)-1)/3.0
        public const double CIRCLE_ALPHA = 0.552284749830793;

        // round integer epsilon
        public const double SHORT_EPSILON = 0.1;
        // percentage epsilon
        public const double PERC_EPSILON = 0.001;
        // single float average epsilon
        public const double EPSILON = 0.0001;
        // arbitrary 8 digit epsilon
        public const double LONG_EPSILON = 1E-08;



        public static double interpolateAngle(double a1, double a2, double weight, bool useRadians)
        {
            a1 = normalizeAngle(a1, useRadians);
            a2 = normalizeAngleToAnother(a2, a1, useRadians);

            return interpolate(a1, a2, weight);
        }

        public static double interpolate(double a, double b, double weight)
        {
            return (b - a) * weight + a;
        }


        public static double interpolateAngle(double a1, double a2, double weight)
        {
            return interpolateAngle(a1, a2, weight, true);
        }


        public static double normalizeAngleToAnother(double dep, double ind, bool useRadians)
        {
            return ind + nearestAngleBetween(ind, dep, useRadians);
        }

        public static double normalizeAngleToAnother(double dep, double ind)
        {
            return normalizeAngleToAnother(dep, ind, true);
        }

        public static double nearestAngleBetween(double a1, double a2)
        {
            return nearestAngleBetween(a1, a2, true);
        }

        public static double nearestAngleBetween(double a1, double a2, bool useRadians)
        {
            double rd_2 = (useRadians ? PI_2 : 90);
            double two_rd = (useRadians ? TWO_PI : 360);

            a1 = normalizeAngle(a1);
            a2 = normalizeAngle(a2);

            if (a1 < -rd_2 & a2 > rd_2)
                a1 += two_rd;
            if (a2 < -rd_2 & a1 > rd_2)
                a2 += two_rd;

            return a2 - a1;
        }

        public static double normalizeAngle(double angle)
        {
            return normalizeAngle(angle, true);
        }

        public static double normalizeAngle(double angle, bool useRadians)
        {
            double rd = (useRadians ? PI : 180);
            return wrap(angle, rd, -rd);
        }

        public static double wrap(double value, double max, double min = 0)
        {
            value -= min;
            max -= min;

            if (max == 0)
                return min;

            value = value % max;
            value += min;

            while (value < min)
            {
                value += max;
            }

            return value;
        }

        public static bool isInRange(double value, double max, double min)
        {
            return (value >= min && value <= max);
        }
 
        public static bool isInRange(double value, double max)
        {
            return isInRange(value, max, 0);
        }

    }
}
