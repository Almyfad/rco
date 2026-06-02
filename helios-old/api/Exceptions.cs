
    public class ApiException : Exception
    {
        public ApiException(string message) : base(message)
        {
        }
    }

    public class UnauthorizedException : ApiException
    {
        public UnauthorizedException(string message) : base(message)
        {
        }
    }

    public class NotEnoughPrivilegeException : ApiException
    {
        public NotEnoughPrivilegeException(string message) : base(message)
        {
        }
    }

    public class ForbiddenException : ApiException
    {
        public ForbiddenException(string message) : base(message)
        {
        }
    }

    public class UnhandledException : ApiException
    {
        public UnhandledException(string message) : base(message)
        {
        }
    }

    public class  BadRequestException : ApiException
    {
        public BadRequestException(string message) : base(message)
        {
                
        }
    }


