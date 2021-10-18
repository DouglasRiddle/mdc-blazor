namespace MdcBlazor
{
    /// <summary>
    /// Class used to store MdcCircularProgress display values
    /// </summary>
    public class MdcCircularProgressValue
    {
        /// <value>The r value</value>
        public string RValue { get; set; }
        /// <value>The pixel size value</value>
        public int SizeValue { get; set; }
        /// <value>The stroke-dasharray value</value>
        public string StrokeDashArrayValue { get; set; }
        /// <value>The stroke-dashoffset value</value>
        public string StrokeDashOffsetValue { get; set; }
        /// <value>The gap patch stroke-width value</value>
        public string StrokeWidthGapValue { get; set; }
        /// <value>The stroke-width value</value>
        public string StrokeWidthValue { get; set; }

        /* Dynamic Properties */
        /// <value>The cx and cy value</value>
        public string CxCyValue { get { return (SizeValue / 2).ToString(); } }
        /// <value>The string value of <c>SizeValue</c></value>
        private string SizeString => SizeValue.ToString();
        /// <value>The style width and height values</value>
        public string StyleValue { get { return $"width: {SizeString}px; height: {SizeString}px;"; } }
        /// <value>The viewBox value</value>
        public string ViewBoxValue { get { return $"0 0 {SizeString} {SizeString}"; } }
    }
}
