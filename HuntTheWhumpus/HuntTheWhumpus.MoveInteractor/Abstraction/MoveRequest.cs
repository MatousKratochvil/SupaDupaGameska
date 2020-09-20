using System;

namespace HuntTheWhumpus.Interactor.Abstraction
{
	public abstract class MoveRequest
	{
		protected MoveRequest(Guid moveableId)
		{
			MoveableId = moveableId;
		}

		internal Guid MoveableId { get; }
	}
}