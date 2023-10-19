using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Misskey_WinUI.pages;
using System;
using System.Collections.Generic;

namespace Misskey_WinUI {
    public sealed partial class MainWindow : Window {
        public List<MenuItem> MenuItems = new() {
            new MenuItem("タイムライン", "\uE80F", nameof(Timeline), typeof(Timeline)),
            new MenuItem("通知", "\uE91C", nameof(Notice), typeof(Notice)),
            new MenuItem("お気に入り", "\uE734", nameof(Favorites), typeof(Favorites)),
            new MenuItem("ドライブ", "\uE753", nameof(Drive), typeof(Drive)),
            new MenuItem("みつける", "\uE8EC", nameof(Find), typeof(Find)),
            new MenuItem("お知らせ", "\uE789", nameof(SystemNotice), typeof(SystemNotice)),
            new MenuItem("検索", "\uE721", nameof(Search), typeof(Search)),
            new MenuItem("null", "\uE721", "null", null),
        };

        public MainWindow() {
            this.InitializeComponent();
        }

        private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args) {
            var selectedItem = args.SelectedItemContainer as NavigationViewItem;
            if(selectedItem != null) {
                if (!args.IsSettingsSelected) {
                    var page = MenuItems.Find((item) => selectedItem.AccessKey == item.AccessKey);
                    if (page.Page != null) {
                        frame.Navigate(page.Page);
                    }
                    else {
                        frame.Navigate(typeof(NotFound));
                    }
                }
                else {
                    frame.Navigate(typeof(Settings));
                }
            }
        }
    }

    public class MenuItem {
        public string MenuText { get; }
        public string Glyph { get; }
        public string AccessKey { get; }
        public Type Page { get; }

        public MenuItem(string menutext, string glyph, string accesskey, Type page) {
            MenuText = menutext;
            Glyph = glyph;
            AccessKey = accesskey;
            Page = page;
        }
    }
}
