using System;
using HuntTheWhumpus.ShootInteractor.Abstraction;
using MediatR;

namespace HuntTheWhumpus.ShootInteractor.Shoot
{
	public class ShootLeftRequest : ShootRequest, IRequest
	{
		public ShootLeftRequest(Guid shootableId) : base(shootableId)
		{
		}
	}
}