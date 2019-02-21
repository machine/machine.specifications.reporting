using System;
using System.Text.Encodings.Web;

using Machine.Specifications.Reporting.Model;

using Spark;

namespace Machine.Specifications.Reporting.Generation.Spark
{
    public abstract class SparkView : AbstractSparkView
    {
        public Run Model
        {
            get;
            set;
        }

        public string H(object value)
        {
            return HtmlEncoder.Default.Encode(Convert.ToString(value));
        }

        public static string Pluralize(string caption, int count)
        {
            if (count > 1 || count == 0)
            {
                caption += "s";
            }

            return caption;
        }
    }
}
