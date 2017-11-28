using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;

namespace xapps.iOS
{
    public class ListSelectorViewSource : UITableViewSource
    {
        // declare vars
        IList<ListPageItem> tableItems;
        ListSelectorView listView;
        readonly NSString cellIdentifier = new NSString("TableCell");

        public IEnumerable<ListPageItem> Items
        {
            set
            {
                tableItems = value.ToList();
            }
        }

        public ListSelectorViewSource(ListSelectorView view)
        {
            tableItems = view.Items.ToList();
            listView = view;
        }

        /// <summary>
        /// Called by the TableView to determine how many cells to create for that particular section.
        /// </summary>
        public override nint RowsInSection(UITableView tableview, nint section)
        {
            Console.WriteLine("RowsInSection() Count : " + tableItems.Count);
            return tableItems.Count;
        }

        #region user interaction methods
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            listView.NotifyItemSelected(tableItems[indexPath.Row]);
            Console.WriteLine("Row " + indexPath.Row.ToString() + " selected");
            tableView.DeselectRow(indexPath, true);
        }

        public override void RowDeselected(UITableView tableView, NSIndexPath indexPath)
        {
            Console.WriteLine("Row " + indexPath.Row.ToString() + " deselected");
        }
        #endregion

        /// <summary>
        /// Called by the TableView to get the actual UITableViewCell to render for the particular section and row
        /// </summary>
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            Console.WriteLine("GetCell()");

            // request a recycled cell to save memory
            ListSelectorViewCell cell = tableView.DequeueReusableCell(cellIdentifier) as ListSelectorViewCell;

            // if there are no cells to reuse, create a new one
            if (cell == null)
            {
                Console.WriteLine("GetCell() cell == null");
                cell = new ListSelectorViewCell(cellIdentifier);
            }

            //if (String.IsNullOrWhiteSpace(tableItems[indexPath.Row].ImageFilename))
            //{
            //    cell.UpdateCell(tableItems[indexPath.Row].Name
            //        , tableItems[indexPath.Row].Category
            //        , null);
            //}
            //else
            //{
            //cell.UpdateCell(tableItems[indexPath.Row].Name
            //, tableItems[indexPath.Row].Category
            //, UIImage.FromFile("Images/" + tableItems[indexPath.Row].ImageFilename + ".jpg"));
            //}

            cell.UpdateCell(tableItems[indexPath.Row].Title
                            , tableItems[indexPath.Row].Description
            , null);

            return cell;
        }
    }
}
