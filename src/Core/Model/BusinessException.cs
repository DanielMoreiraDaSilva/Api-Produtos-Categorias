using System;

namespace Lab.Core.Model
{
    public class BusinessException : Exception
    {
        public BusinessException()
        {
        }

        public BusinessException(string errorMessage)
        : base(errorMessage)
        {

        }

    }
}