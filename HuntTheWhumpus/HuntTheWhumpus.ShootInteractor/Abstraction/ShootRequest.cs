using System;

namespace HuntTheWhumpus.ShootInteractor.Abstraction
{
	public abstract class ShootRequest
	{
		protected ShootRequest(Guid shootableId)
		{
			ShootableId = shootableId;
		}

		internal Guid ShootableId { get; }
	}
}