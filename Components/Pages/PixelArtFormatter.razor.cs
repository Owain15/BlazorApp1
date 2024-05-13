using BlazorApp1.Components.Pages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Components.Pages
{
    public record RGB(int R, int G, int B)
    {
        public string ToBackground() => $"background: rgb({this.R}, {this.G}, {this.B});";
    };

    public record GridSize(int ColumnCount, int RowCount);

    // Generics example.

    class NextListBuddy<T>
    {
        T GetNext(List<T> list, int index)
        {
            var buddy = new NextListBuddy<RGB>();

            throw new NotImplementedException();
        }
    }

    public partial class PixelArtFormatter
    {
        string SelectedValue = null;

        int inputRow = 10;
        int inputColumn = 10;

        RGB[,] cells = null;
        //new RGB[10, 10];


        List<SelectListItem> Presets =
        [
            new("Small Sprite (20,30)px", System.Text.Json.JsonSerializer.Serialize(new GridSize(20, 30))),
            new("Medium Sprite (30,60)px", System.Text.Json.JsonSerializer.Serialize(new GridSize(30, 60)))
        ];


        protected override void OnInitialized()
        {
            //for (int colIndex = 0; colIndex < cells.GetLength(0); colIndex++)
            //{
            //    for (int rowIndex = 0; rowIndex < cells.GetLength(1); rowIndex++)
            //    {
            //        cells[colIndex, rowIndex] = colors.First();

            //    }
            //}
        }

        public void SetPresetDimentions(int[] values)
        {
            inputColumn = values[0];
            inputRow = values[1];
        }


        public RGB IncrementColor(int colIndex, int rowIndex)
        {
            var index = colors.FindIndex(it => it == cells[colIndex, rowIndex]);

            // ternary operator.
            var color = index + 1 < colors.Count ? colors[index + 1] : colors[0];

            // modulus operator.
            // var color = colors[(index + 1) % (colors.Count )];

            //var color = GetNextColor(colors, index);

            cells[colIndex, rowIndex] = color;
            return color;
        }

        public RGB GetNextColor(List<RGB> cols, int index)
        {


            if (index + 1 > cols.Count)
            {
                return cols[0];
            }
            return cols[index + 1];
        }

        private List<RGB> colors = new List<RGB>()
    {
        new RGB(0,0,0),
        new RGB(255,255,255),
        new RGB(255,100,100),
        new RGB(100,255,100),
        new RGB(100,100,255)
    };

        public GridSize SelectedValueModel = null;
        private void UpdateSelectedValueModel(Microsoft.AspNetCore.Components.ChangeEventArgs e)
        {
            var input = (string)e.Value;
            SelectedValueModel = System.Text.Json.JsonSerializer.Deserialize<GridSize>(input);

            inputColumn = SelectedValueModel.ColumnCount;
            inputRow = SelectedValueModel.RowCount;

        }
        private void CreateNewButtonOnClick(Microsoft.AspNetCore.Components.Web.MouseEventArgs e) => CreateNewProject();

        private void CreateNewProject()
        {
            cells = new RGB[inputColumn, inputRow];
            for (int c = 0; c < cells.GetLength(0); c++)
            {
                for (int r = 0; r < cells.GetLength(1); r++)
                {
                    cells[c,r]= new RGB(100,100,100);
                }
            }

        }
    }


}

