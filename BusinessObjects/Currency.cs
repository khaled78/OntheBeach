using System;


namespace BusinessObjects
{
    /// <summary>
    /// Class to represent Currency
    /// </summary>
   public class Currency
    {
       /// <summary>
       /// Gets or sets Unit
       /// </summary>
       public string Unit { get; set; }

       /// <summary>
       /// Gets or sets Conversion Factor to GBP
       /// </summary>
       public double ConversionFactor { get; set; }
    }
}
