using System.Drawing;
using System.Windows.Forms;
using BrightIdeasSoftware;

namespace Cars {
  public static class Tools {
    /// <summary>
    // Первичная настройка ObjectListView
    /// </summary>
    /// <param name="olv">ObjectListView для первичной настройки</param>
    public static void SetUpOlv(ObjectListView olv) {
      olv.MultiSelect = true;
      olv.ShowGroups = false;
      olv.BackColor = Color.AliceBlue;
      olv.UseAlternatingBackColors = true;
      olv.AlternateRowBackColor = Color.LightBlue;
      olv.FullRowSelect = true;
      olv.HideSelection = false;
      olv.UseCustomSelectionColors = true;
      olv.HideSelection = false;
      olv.HotTracking = false;
      olv.HoverSelection = false;
      olv.Activation = ItemActivation.Standard;
      olv.Font = new Font(FontFamily.GenericSansSerif, 12);
      olv.MultiSelect = false;
    }

    public static void ResizeColumns(ObjectListView olv) {
      foreach (ColumnHeader col in olv.Columns) {
        col.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
      }
    }
  }
}