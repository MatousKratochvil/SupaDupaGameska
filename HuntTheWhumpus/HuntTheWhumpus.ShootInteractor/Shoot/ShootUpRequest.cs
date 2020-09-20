using System;
using HuntTheWhumpus.ShootInteractor.Abstraction;
using MediatR;

namespace HuntTheWhumpus.ShootInteractor.Shoot
{ 
	public class ShootUpRequest : ShootRequest, IRequest
	{
		public ShootUpRequest(Guid shootableId) : base(shootableId)
		{
		}
	}
}