namespace HuntTheWhumpus.Core.Domain
{
	public class Whumpus
	{
		int _actualRoomId;

		public Whumpus(int actualRoomId)
		{
			_actualRoomId = actualRoomId;
		}
		
		public void SetActualRoom(int roomId) => _actualRoomId = roomId;
		
		public int GetActualRoomId() => _actualRoomId;
	}
}