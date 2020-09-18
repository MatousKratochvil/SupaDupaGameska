using System;

namespace HuntTheWhumpus.Interactor.Abstraction
{
	public abstract class DirectionRequest
	{
		protected DirectionRequest(Guid moveableId)
		{
			MoveableId = moveableId;
		}

		internal Guid MoveableId { get; }
	}
}