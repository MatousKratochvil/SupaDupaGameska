using System;
using HuntTheWhumpus.ShootInteractor.Abstraction;
using MediatR;

namespace HuntTheWhumpus.ShootInteractor.Shoot
{
	public class ShootDownRequest : ShootRequest, IRequest
	{
		public ShootDownRequest(Guid shootableId) : base(shootableId)
		{
		}
	}
}