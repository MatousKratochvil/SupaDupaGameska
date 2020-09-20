using System;
using HuntTheWhumpus.ShootInteractor.Abstraction;
using MediatR;

namespace HuntTheWhumpus.ShootInteractor.Shoot
{
	public class ShootRightRequest : ShootRequest, IRequest
	{
		public ShootRightRequest(Guid shootableId) : base(shootableId)
		{
		}
	}
}