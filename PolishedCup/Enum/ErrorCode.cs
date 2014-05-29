using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace PolishedCup.Enum
{
    public enum ErrorCode
    {
        UnauthorizedRequest = (int)HttpStatusCode.Unauthorized, // 401
        BadRequest = (int)HttpStatusCode.BadRequest, // 400
        MissingResource = (int)HttpStatusCode.NotFound, // 404
        InternalServerError = (int)HttpStatusCode.InternalServerError, // 500
        NotImplemented = (int)HttpStatusCode.NotImplemented, // 501
        ServiceFailure = 600,
        AuthenticationFailure = 700,
    }

}