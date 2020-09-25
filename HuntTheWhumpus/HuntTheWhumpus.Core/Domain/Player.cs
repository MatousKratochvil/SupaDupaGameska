namespace HuntTheWhumpus.Core.Domain
{
	public sealed class Player
	{
		int _actualRoomId;
		int _ammunition;

		public Player(int actualRoomId, int ammunition)
		{
			_actualRoomId = actualRoomId;
			_ammunition = ammunition;
		}
		
		public void SetActualRoom(int roomId) => _actualRoomId = roomId;
		public int GetActualRoomId() => _actualRoomId;

		public void Shoot() => _ammunition--;

		public bool HasAmmunition() => _ammunition > 0;
	}
}