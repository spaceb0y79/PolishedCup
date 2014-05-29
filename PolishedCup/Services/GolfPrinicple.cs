using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;

namespace PolishedCup.Services
{
    public class GolfPrincipal : GenericPrincipal
    {
        private SessionService _session;
		public GolfPrincipal(SessionService session)
			: base(
				new GenericIdentity(session.PlayerUserName),
				new string[] { })
		{
			this._session = session;
		}

		public SessionService Session
		{
			get
			{
				return _session;
			}
		}

    }
}

