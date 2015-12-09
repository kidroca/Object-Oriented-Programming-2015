namespace P5_Word_Document_Generator
{
    using System;
    using System.Linq;
    using HomeworkHelpers;
    using Novacode;

    public class Program
    {
        private static readonly StreamHomeworkHelper Helper = new StreamHomeworkHelper();

        [STAThread]
        private static void Main(string[] args)
        {
            string savePath = Helper.SelectSaveLocation(filter: "Word files (*.docx)|*.docx");

            var doc = DocX.Create(savePath);

            var headingFormat = new Formatting()
            {
                Size = 20
            };

            Paragraph h1 = doc.InsertParagraph("SoftUni OOP Game Contest", false, headingFormat);
            h1.Alignment = Alignment.center;

            var formattingBold = new Formatting()
            {
                Bold = true
            };

            var formattingUnderlined = new Formatting()
            {
                Bold = true,
                UnderlineStyle = UnderlineStyle.singleLine
            };

            Paragraph p = doc.InsertParagraph(
                "SoftUni is organizing a contest for the best ", false);
            p.InsertText("role playing game", false, formattingBold);
            p.InsertText(" from the OOP teamwork projects. The winning teams will receive a ");
            p.InsertText("grand prize!", false, formattingUnderlined);

            Picture pic = doc.AddImage("rpg-game.png").CreatePicture(400, 720);
            p.InsertPicture(pic);

            List ul = doc.AddList(listType: ListItemType.Bulleted);
            doc.AddListItem(ul, "Properly structured and follow all good OOP practices");
            doc.AddListItem(ul, "Awesome");
            doc.AddListItem(ul, "..Very Awesome");
            doc.InsertList(ul);

            Table table = doc.AddTable(4, 3);
            table.Alignment = Alignment.center;
            table.Design = TableDesign.ColorfulGridAccent2;

            Row tr = table.Rows[0];

            tr.Cells[0].Paragraphs.First().Append("Team");
            tr.Cells[1].Paragraphs.First().Append("Game");
            tr.Cells[2].Paragraphs.First().Append("Points");

            for (int i = 1; i < table.RowCount; i++)
            {
                foreach (var cell in table.Rows[i].Cells)
                {
                    cell.Paragraphs.First().Append(" - ");
                }
            }

            doc.InsertTable(table);

            // Not interesting + Big Hamalogia = stiga tolkoz...
            doc.Save();
        }
    }
}