using System;
using System.Text;

using Bll.Executers.Abstractions;

using NLog;

using NumberSystemConverter.abstraction;

namespace Bll.Executers
{
    public class NumberConverter : IExecuter
    {
        #region Fields

        private INumberConverter _converter;
        private Logger _logger;

        #endregion

        #region Ctor

        public NumberConverter(INumberConverter converter)
        {
            _converter = converter;
            _logger = LogManager.GetCurrentClassLogger();
        }

        #endregion

        #region Methods

        public string Calculation(string text)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.Append(_converter.Conversion(text));
            }
            catch(Exception ex)
            {
                _logger.Error(ex);
                sb.Append("0");
            }
            return sb.ToString();
        }

        #endregion
    }
}
