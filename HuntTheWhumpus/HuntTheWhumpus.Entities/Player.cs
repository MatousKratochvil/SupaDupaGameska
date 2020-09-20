using System;
using HuntTheWhumpus.Entities.Interfaces;

namespace HuntTheWhumpus.Entities
{
	public class Player : IMoveableEntity, IShootableEntity 
	{
		int _x;
		int _y;
		int _shootX;
		int _shootY;
		
		public Guid Id { get; }

		int IEntity<Guid>.X
		{
			get => _x;
			set => _x = value;
		}

		int IEntity<Guid>.Y
		{
			get => _y;
			set => _y = value;
		}

		int IShootableEntity.ShootX
		{
			get => _shootX;
			set => _shootX = value;
		}

		int IShootableEntity.ShootY
		{
			get => _shootY;
			set => _shootY = value;
		}
	}
}