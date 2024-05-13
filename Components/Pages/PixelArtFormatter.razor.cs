namespace BlazorApp1.Components.Pages
{
	
	
	public class PixelArtFormatterLogic
	{
		
		private int row;
	    private int column;

		private int[] pixelReff;
		
		//public PixelArtFormatterLogic(int inputRow,int inputColumn)
		//{
		//	row = inputRow;
		//	column = inputColumn;

		//	pixelReff = new int[column*row];
		//}

		public enum presets
		{
			GameBoy,
			GameBoyAdvanced,
			NES,
			SagaGenesis
		}
		public enum colorPalette
		{
			Black,
			Aqua,
			DarkGreen,
			White
		}

		// rowUpdate() {

		// }

		

		//int[] pixelArray = GenerateNewIntArray(30,20);

		public int[] NewProject(int column,int row)
		{ 
			return new int[column*row]; 
		}
		

	}
}
