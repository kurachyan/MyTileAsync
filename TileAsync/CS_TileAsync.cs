using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace TileAsync
{
    public class CS_TileAsync
    {   // Tile_Set
        #region 共有領域
        private String _Title;
        private List<String> _SubTitle;
        private List<String> _Message;
        private List<String> _Image;
        public String Title
        {
            get
            {
                return _Title;
            }
            set
            {
                _Title = value;
            }
        }
        public enum Ver_Type
        {
            Version1,               // Windows8
            Version2,               // Windows8.1
            Unknown                 // Unknown
        }
        private Ver_Type _Ver;
        private static String[] Tile_Table_B =
        {   // 名称：［Windows8 Version1］
            "TileSquareImage",                  // 0 [150*150]
            "TileSquareBlock",                  // 1
            "TileSquareText01",                 // 2
            "TileSquareText02",                 // 3
            "TileSquareText03",                 // 4
            "TileSquareText04",                 // 5
            "TileSquarePeekImageAndText01",     // 6
            "TileSquarePeekImageAndText02",     // 7
            "TileSquarePeekImageAndText03",     // 8
            "TileSquarePeekImageAndText04",     // 9
            "TileWideImage",                    // 10 [310*150]
            "TileWideImageCollection",          // 11
            "TileWideImageAndText01",           // 12
            "TileWideImageAndText02",           // 13
            "TileWideBlockAndText01",           // 14
            "TileWideBlockAndText02",           // 15
            "TileWidePeekImageCollection01",    // 16
            "TileWidePeekImageCollection02",    // 17
            "TileWidePeekImageCollection03",    // 18
            "TileWidePeekImageCollection04",    // 19
            "TileWidePeekImageCollection05",    // 20
            "TileWidePeekImageCollection06",    // 21
            "TileWidePeekImageAndText01",       // 22
            "TileWidePeekImageAndText02",       // 23
            "TileWidePeekImage01",              // 24
            "TileWidePeekImage02",              // 25
            "TileWidePeekImage03",              // 26
            "TileWidePeekImage04",              // 27
            "TileWidePeekImage05",              // 28
            "TileWidePeekImage06",              // 29
            "TileWideSmallImageAndText01",      // 30
            "TileWideSmallImageAndText02",      // 31
            "TileWideSmallImageAndText03",      // 32
            "TileWideSmallImageAndText04",      // 33
            "TileWideSmallImageAndText05",      // 34
            "TileWideText01",                   // 35
            "TileWideText02",                   // 36
            "TileWideText03",                   // 37
            "TileWideText04",                   // 38
            "TileWideText05",                   // 39
            "TileWideText06",                   // 40
            "TileWideText07",                   // 41
            "TileWideText08",                   // 42
            "TileWideText09",                   // 43
            "TileWideText10",                   // 44
            "TileWideText11"                    // 45
        };
        private static String[] Tile_Table_A =
        {   // 名称：［Windows8.1 Version2］
            "TileSquare150x150Image",                  // 0 [150*150]
            "TileSquare150x150Block",                  // 1
            "TileSquare150x150Text01",                 // 2
            "TileSquare150x150Text02",                 // 3
            "TileSquare150x150Text03",                 // 4
            "TileSquare150x150Text04",                 // 5
            "TileSquare150x150PeekImageAndText01",     // 6
            "TileSquare150x150PeekImageAndText02",     // 7
            "TileSquare150x150PeekImageAndText03",     // 8
            "TileSquare150x150PeekImageAndText04",     // 9
            "TileWide310x150Image",                    // 10 [310*150]
            "TileWide310x150ImageCollection",          // 11
            "TileWide310x150ImageAndText01",           // 12
            "TileWide310x150ImageAndText02",           // 13
            "TileWide310x150BlockAndText01",           // 14
            "TileWide310x150BlockAndText02",           // 15
            "TileWide310x150PeekImageCollection01",    // 16
            "TileWide310x150PeekImageCollection02",    // 17
            "TileWide310x150PeekImageCollection03",    // 18
            "TileWide310x150PeekImageCollection04",    // 19
            "TileWide310x150PeekImageCollection05",    // 20
            "TileWide310x150PeekImageCollection06",    // 21
            "TileWide310x150PeekImageAndText01",       // 22
            "TileWide310x150PeekImageAndText02",       // 23
            "TileWide310x150PeekImage01",              // 24
            "TileWide310x150PeekImage02",              // 25
            "TileWide310x150PeekImage03",              // 26
            "TileWide310x150PeekImage04",              // 27
            "TileWide310x150PeekImage05",              // 28
            "TileWide310x150PeekImage06",              // 29
            "TileWide310x150SmallImageAndText01",      // 30
            "TileWide310x150SmallImageAndText02",      // 31
            "TileWide310x150SmallImageAndText03",      // 32
            "TileWide310x150SmallImageAndText04",      // 33
            "TileWide310x150SmallImageAndText05",      // 34
            "TileWide310x150Text01",                   // 35
            "TileWide310x150Text02",                   // 36
            "TileWide310x150Text03",                   // 37
            "TileWide310x150Text04",                   // 38
            "TileWide310x150Text05",                   // 39
            "TileWide310x150Text06",                   // 40
            "TileWide310x150Text07",                   // 41
            "TileWide310x150Text08",                   // 42
            "TileWide310x150Text09",                   // 43
            "TileWide310x150Text10",                   // 44
            "TileWide310x150Text11",                   // 45
            "TileSquare310x310BlockAndText01",         // 46
            "TileSquare310x310BlockAndText02",         // 47
            "TileSquare310x310Image",                  // 48
            "TileSquare310x310ImageAndText01",         // 49
            "TileSquare310x310ImageAndText02",         // 50
            "TileSquare310x310ImageAndTextOverlay01",  // 51
            "TileSquare310x310ImageAndTextOverlay02",  // 52
            "TileSquare310x310ImageAndTextOverlay03",  // 53
            "TileSquare310x310ImageCollectionAndText01",	// 54
            "TileSquare310x310ImageCollectionAndText02",	// 55
            "TileSquare310x310ImageCollection",				// 56
            "TileSquare310x310SmallImagesAndTextList01",	// 57
            "TileSquare310x310SmallImagesAndTextList02",	// 58
            "TileSquare310x310SmallImagesAndTextList03",	// 59
            "TileSquare310x310SmallImagesAndTextList04",	// 60
            "TileSquare310x310Text01",					// 61
            "TileSquare310x310Text02",					// 62
			"TileSquare310x310Text03",					// 63
			"TileSquare310x310Text04",					// 64
			"TileSquare310x310Text05",					// 65
			"TileSquare310x310Text06",					// 66
			"TileSquare310x310Text07",					// 67
			"TileSquare310x310Text08",					// 68
			"TileSquare310x310TextList01",				// 69
			"TileSquare310x310TextList02",				// 70
			"TileSquare310x310TextList03",				// 71
			"TileSquare310x310SmallImageAndText01",		// 72
            "TileSquare310x310SmallImagesAndTextList05",	// 73
            "TileSquare310x310Text09",					// 74
            "TileSquare99x99IconWithBadge",     // 1000
            "TileSquare210x210IconWithBadge",     // 1001
            "TileWide432x210IconWithBadgeAndText"		// 1002
        };
        private Windows.UI.Notifications.TileTemplateType _TType;
        public Windows.UI.Notifications.TileTemplateType TType
        {
            get
            {
                return _TType;
            }
            set
            {
                _TType = value;
            }
        }
        #endregion

        #region コンストラクタ
        public CS_TileAsync()
        {
            _Title = "";
            _Message = new List<string>();
            _SubTitle = new List<string>();
            _Image = new List<string>();

            _Ver = Ver_Type.Unknown;        // Unknown
        }
        public CS_TileAsync(Ver_Type __Ver)
        {
            _Title = "";
            _Message = new List<string>();
            _SubTitle = new List<string>();
            _Image = new List<string>();

            _Ver = __Ver;
        }
        public CS_TileAsync(Ver_Type __Ver, Windows.UI.Notifications.TileTemplateType __TType)
        {
            _Title = "";
            _Message = new List<string>();
            _SubTitle = new List<string>();
            _Image = new List<string>();

            _Ver = __Ver;
            _TType = __TType;
        }
        #endregion

        #region 基本設定
        public async Task Set_MessageAsync(List<String> __Message)
        {
            foreach (String __Word in __Message)
            {
                await Task.Factory.StartNew(() =>
                {
                    _Message.Add(__Word);
                });
            }
        }
        public async Task Add_MessageAsync(String __Message)
        {
            await Task.Factory.StartNew(() =>
            {
                _Message.Add(__Message);
            });
        }
        public async Task Clr_MessageAsync()
        {
            if (_Message.Count != 0)
            {
                await Task.Factory.StartNew(() =>
                {
                    _Message.Clear();
                });
            }
        }
        public async Task Set_SubTitleAsync(List<String> __SubTitle)
        {
            foreach (String __Word in __SubTitle)
            {
                await Task.Factory.StartNew(() =>
                {
                    _SubTitle.Add(__Word);
                });
            }
        }
        public async Task Clr_SubTitleAsync()
        {
            if (_SubTitle.Count != 0)
            {
                await Task.Factory.StartNew(() =>
                {
                    _SubTitle.Clear();
                });
            }
        }
        public async Task Set_ImageAsync(List<String> __Image)
        {
            foreach (String __Word in __Image)
            {
                await Task.Factory.StartNew(() =>
                {
                    _Image.Add(__Word);
                });
            }
        }
        public async Task Add_ImageAsync(String __Image)
        {
            await Task.Factory.StartNew(() =>
            {
                _Image.Add(__Image);
            });
        }
        public async Task Clr_ImageAsync()
        {
            if (_Image.Count != 0)
            {
                await Task.Factory.StartNew(() =>
                {
                    _Image.Clear();
                });
            }
        }
        #endregion

        #region 実行
        public async Task ExecAsync()
        {
            var updater = TileUpdateManager.CreateTileUpdaterForApplication();

            updater.Clear();                            // タイルの削除
            updater.EnableNotificationQueue(true);     // 予約情報の許可

            await Task.Factory.StartNew(() =>
            {
                var tileXml = TileUpdateManager.GetTemplateContent(_TType);

                if (_Ver == Ver_Type.Version2)
                {
                    Set_Xml2(ref tileXml);      // [Win8.1]
                }
                else
                {
                    Set_Xml1(ref tileXml);      // [Win8]
                }

                updater.Update(new TileNotification(tileXml));
            });
        }
        public async Task ExecAsync(DateTimeOffset deliveryTime)
        {
            var updater = TileUpdateManager.CreateTileUpdaterForApplication();

            updater.Clear();                            // タイルの削除
            updater.EnableNotificationQueue(true);     // 予約情報の許可

            await Task.Factory.StartNew(() =>
            {
                var tileXml = TileUpdateManager.GetTemplateContent(_TType);

                if (_Ver == Ver_Type.Version2)
                {
                    Set_Xml2(ref tileXml);      // [Win8.1]
                }
                else
                {
                    Set_Xml1(ref tileXml);      // [Win8]
                }

                //            var dueTime = DateTime.Now.AddSeconds(60);
                var scheduledTileNotification = new ScheduledTileNotification(tileXml, deliveryTime);
                updater.AddToSchedule(scheduledTileNotification);
            });
        }
        public async Task DeleteAsync()
        {
            await Task.Factory.StartNew(() =>
            {
                var updater = TileUpdateManager.CreateTileUpdaterForApplication();

                updater.Clear();        // タイルの削除

                updater.EnableNotificationQueue(false);     // 予約情報の削除
            });
        }
        #endregion

        #region その他
        public void Set_Win()
        {
            _Ver = Ver_Type.Version1;       // Set [Windows8]
        }
        public void Set_Win81()
        {
            _Ver = Ver_Type.Version2;       // Set [Windows8.1]
        }
        public void Set_Xml1(ref Windows.Data.Xml.Dom.XmlDocument _tileXml)
        {   // For [Windows8]
            XmlNodeList xnl;

            switch (_TType)
            {
                case TileTemplateType.TileSquareImage:
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"alt text");
                    break;
                case TileTemplateType.TileSquareBlock:
                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Title;
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[0];
                    break;
                case TileTemplateType.TileSquareText01:
                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Title;
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[0];
                    _tileXml.GetElementsByTagName("text")[2].InnerText = _Message[1];
                    _tileXml.GetElementsByTagName("text")[3].InnerText = _Message[2];
                    break;
                case TileTemplateType.TileSquareText02:
                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Title;
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[0];
                    break;
                case TileTemplateType.TileSquareText03:
                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Message[0];
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[1];
                    _tileXml.GetElementsByTagName("text")[2].InnerText = _Message[2];
                    _tileXml.GetElementsByTagName("text")[3].InnerText = _Message[3];
                    break;
                case TileTemplateType.TileSquareText04:
                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Message[0];
                    break;
                case TileTemplateType.TileSquarePeekImageAndText01:
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"alt text");
                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Title;
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[0];
                    _tileXml.GetElementsByTagName("text")[2].InnerText = _Message[1];
                    _tileXml.GetElementsByTagName("text")[3].InnerText = _Message[2];
                    break;
                case TileTemplateType.TileSquarePeekImageAndText02:
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"alt text");

                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Title;
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[0];
                    break;
                case TileTemplateType.TileSquarePeekImageAndText03:
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"alt text");
                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Message[0];
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[1];
                    _tileXml.GetElementsByTagName("text")[2].InnerText = _Message[2];
                    _tileXml.GetElementsByTagName("text")[3].InnerText = _Message[3];
                    break;
                case TileTemplateType.TileSquarePeekImageAndText04:
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"alt text");
                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Message[0];
                    break;
                case TileTemplateType.TileWideImage:
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"alt text");
                    break;
                case TileTemplateType.TileWideImageCollection:
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"larger image");
                    ((XmlElement)xnl[1]).SetAttribute("src", _Image[1]);
                    ((XmlElement)xnl[1]).SetAttribute("alt", @"small image, row 1, column 1");
                    ((XmlElement)xnl[2]).SetAttribute("src", _Image[2]);
                    ((XmlElement)xnl[2]).SetAttribute("alt", @"small image, row 1, column 2");
                    ((XmlElement)xnl[3]).SetAttribute("src", _Image[3]);
                    ((XmlElement)xnl[3]).SetAttribute("alt", @"small image, row 2, column 1");
                    ((XmlElement)xnl[4]).SetAttribute("src", _Image[4]);
                    ((XmlElement)xnl[4]).SetAttribute("alt", @"small image, row 2, column 2");
                    break;
                case TileTemplateType.TileWideImageAndText01:
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"alt text");

                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Message[0];
                    break;
                case TileTemplateType.TileWideImageAndText02:
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"alt text");

                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Message[0];
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[1];
                    break;
                case TileTemplateType.TileWideBlockAndText01:
                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Message[0];
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[1];
                    _tileXml.GetElementsByTagName("text")[2].InnerText = _Message[2];
                    _tileXml.GetElementsByTagName("text")[3].InnerText = _Message[3];
                    _tileXml.GetElementsByTagName("text")[4].InnerText = _Title;
                    _tileXml.GetElementsByTagName("text")[5].InnerText = _SubTitle[0];
                    break;
                case TileTemplateType.TileWideBlockAndText02:
                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Message[0];
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Title;
                    _tileXml.GetElementsByTagName("text")[2].InnerText = _SubTitle[0];
                    break;
                case TileTemplateType.TileWidePeekImageCollection01:
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"larger image");
                    ((XmlElement)xnl[1]).SetAttribute("src", _Image[1]);
                    ((XmlElement)xnl[1]).SetAttribute("alt", @"small image, row 1, column 1");
                    ((XmlElement)xnl[2]).SetAttribute("src", _Image[2]);
                    ((XmlElement)xnl[2]).SetAttribute("alt", @"small image, row 1, column 2");
                    ((XmlElement)xnl[3]).SetAttribute("src", _Image[3]);
                    ((XmlElement)xnl[3]).SetAttribute("alt", @"small image, row 2, column 1");
                    ((XmlElement)xnl[4]).SetAttribute("src", _Image[4]);
                    ((XmlElement)xnl[4]).SetAttribute("alt", @"small image, row 2, column 2");

                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Title;
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[0];
                    break;
                case TileTemplateType.TileWidePeekImageCollection02:
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"larger image");
                    ((XmlElement)xnl[1]).SetAttribute("src", _Image[1]);
                    ((XmlElement)xnl[1]).SetAttribute("alt", @"small image, row 1, column 1");
                    ((XmlElement)xnl[2]).SetAttribute("src", _Image[2]);
                    ((XmlElement)xnl[2]).SetAttribute("alt", @"small image, row 1, column 2");
                    ((XmlElement)xnl[3]).SetAttribute("src", _Image[3]);
                    ((XmlElement)xnl[3]).SetAttribute("alt", @"small image, row 2, column 1");
                    ((XmlElement)xnl[4]).SetAttribute("src", _Image[4]);
                    ((XmlElement)xnl[4]).SetAttribute("alt", @"small image, row 2, column 2");

                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Title;
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[0];
                    _tileXml.GetElementsByTagName("text")[2].InnerText = _Message[1];
                    _tileXml.GetElementsByTagName("text")[3].InnerText = _Message[2];
                    _tileXml.GetElementsByTagName("text")[4].InnerText = _Message[3];
                    break;
                case TileTemplateType.TileWidePeekImageCollection03:
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"larger image");
                    ((XmlElement)xnl[1]).SetAttribute("src", _Image[1]);
                    ((XmlElement)xnl[1]).SetAttribute("alt", @"small image, row 1, column 1");
                    ((XmlElement)xnl[2]).SetAttribute("src", _Image[2]);
                    ((XmlElement)xnl[2]).SetAttribute("alt", @"small image, row 1, column 2");
                    ((XmlElement)xnl[3]).SetAttribute("src", _Image[3]);
                    ((XmlElement)xnl[3]).SetAttribute("alt", @"small image, row 2, column 1");
                    ((XmlElement)xnl[4]).SetAttribute("src", _Image[4]);
                    ((XmlElement)xnl[4]).SetAttribute("alt", @"small image, row 2, column 2");

                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Message[0];
                    break;
                case TileTemplateType.TileWidePeekImageCollection04:
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"larger image");
                    ((XmlElement)xnl[1]).SetAttribute("src", _Image[1]);
                    ((XmlElement)xnl[1]).SetAttribute("alt", @"small image, row 1, column 1");
                    ((XmlElement)xnl[2]).SetAttribute("src", _Image[2]);
                    ((XmlElement)xnl[2]).SetAttribute("alt", @"small image, row 1, column 2");
                    ((XmlElement)xnl[3]).SetAttribute("src", _Image[3]);
                    ((XmlElement)xnl[3]).SetAttribute("alt", @"small image, row 2, column 1");
                    ((XmlElement)xnl[4]).SetAttribute("src", _Image[4]);
                    ((XmlElement)xnl[4]).SetAttribute("alt", @"small image, row 2, column 2");

                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Message[0];
                    break;
                case TileTemplateType.TileWidePeekImageCollection05:
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"larger image");
                    ((XmlElement)xnl[1]).SetAttribute("src", _Image[1]);
                    ((XmlElement)xnl[1]).SetAttribute("alt", @"small image, row 1, column 1");
                    ((XmlElement)xnl[2]).SetAttribute("src", _Image[2]);
                    ((XmlElement)xnl[2]).SetAttribute("alt", @"small image, row 1, column 2");
                    ((XmlElement)xnl[3]).SetAttribute("src", _Image[3]);
                    ((XmlElement)xnl[3]).SetAttribute("alt", @"small image, row 2, column 1");
                    ((XmlElement)xnl[4]).SetAttribute("src", _Image[4]);
                    ((XmlElement)xnl[4]).SetAttribute("alt", @"small image, row 2, column 2");
                    ((XmlElement)xnl[5]).SetAttribute("src", _Image[5]);
                    ((XmlElement)xnl[5]).SetAttribute("alt", @"image next to text");

                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Title;
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[0];
                    break;
                case TileTemplateType.TileWidePeekImageCollection06:
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"larger image");
                    ((XmlElement)xnl[1]).SetAttribute("src", _Image[1]);
                    ((XmlElement)xnl[1]).SetAttribute("alt", @"small image, row 1, column 1");
                    ((XmlElement)xnl[2]).SetAttribute("src", _Image[2]);
                    ((XmlElement)xnl[2]).SetAttribute("alt", @"small image, row 1, column 2");
                    ((XmlElement)xnl[3]).SetAttribute("src", _Image[3]);
                    ((XmlElement)xnl[3]).SetAttribute("alt", @"small image, row 2, column 1");
                    ((XmlElement)xnl[4]).SetAttribute("src", _Image[4]);
                    ((XmlElement)xnl[4]).SetAttribute("alt", @"small image, row 2, column 2");
                    ((XmlElement)xnl[5]).SetAttribute("src", _Image[5]);
                    ((XmlElement)xnl[5]).SetAttribute("alt", @"image next to text");

                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Message[0];
                    break;
                case TileTemplateType.TileWidePeekImageAndText01:
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"alt text");

                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Message[0];
                    break;
                case TileTemplateType.TileWidePeekImageAndText02:
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"alt text");

                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Message[0];
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[1];
                    _tileXml.GetElementsByTagName("text")[2].InnerText = _Message[2];
                    _tileXml.GetElementsByTagName("text")[3].InnerText = _Message[3];
                    _tileXml.GetElementsByTagName("text")[4].InnerText = _Message[4];
                    break;
                case TileTemplateType.TileWidePeekImage01:
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"alt text");

                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Title;
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[0];
                    break;
                case TileTemplateType.TileWidePeekImage02:
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"alt text");

                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Title;
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[0];
                    _tileXml.GetElementsByTagName("text")[2].InnerText = _Message[1];
                    _tileXml.GetElementsByTagName("text")[3].InnerText = _Message[2];
                    _tileXml.GetElementsByTagName("text")[4].InnerText = _Message[3];
                    break;
                case TileTemplateType.TileWidePeekImage03:
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"alt text");

                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Message[0];
                    break;
                case TileTemplateType.TileWidePeekImage04:
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"alt text");

                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Message[0];
                    break;
                case TileTemplateType.TileWidePeekImage05:
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"main image");
                    ((XmlElement)xnl[1]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[1]).SetAttribute("alt", @"smaller image next to text");

                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Title;
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[0];
                    break;
                case TileTemplateType.TileWidePeekImage06:
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"main image");
                    ((XmlElement)xnl[1]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[1]).SetAttribute("alt", @"smaller image next to text");

                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Message[0];
                    break;
                case TileTemplateType.TileWideSmallImageAndText01:
#if WINDOWS_APP
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"alt text");
#endif

                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Message[0];
                    break;
                case TileTemplateType.TileWideSmallImageAndText02:
#if WINDOWS_APP
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"alt text");
#endif

                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Title;
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[0];
                    _tileXml.GetElementsByTagName("text")[2].InnerText = _Message[1];
                    _tileXml.GetElementsByTagName("text")[3].InnerText = _Message[2];
                    _tileXml.GetElementsByTagName("text")[4].InnerText = _Message[3];
                    break;
                case TileTemplateType.TileWideSmallImageAndText03:
#if WINDOWS_APP
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"alt text");
#endif

                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Message[0];
                    break;
                case TileTemplateType.TileWideSmallImageAndText04:
#if WINDOWS_APP
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"alt text");
#endif

                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Title;
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[0];
                    break;
                case TileTemplateType.TileWideSmallImageAndText05:
#if WINDOWS_APP
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"alt text");
#endif

                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Title;
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[0];
                    break;
                case TileTemplateType.TileWideText01:
                    //                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Title;
                    _tileXml.GetElementsByTagName("text")[0].InnerText = @"For Windows8";
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[0];
                    _tileXml.GetElementsByTagName("text")[2].InnerText = _Message[1];
                    _tileXml.GetElementsByTagName("text")[3].InnerText = _Message[2];
                    _tileXml.GetElementsByTagName("text")[4].InnerText = _Message[3];
                    break;
                case TileTemplateType.TileWideText02:
#if WINDOWS_APP
                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Title;
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[0];       // Row:1 Col:1
                    _tileXml.GetElementsByTagName("text")[2].InnerText = _Message[1];       // Row:1 Col:2
                    _tileXml.GetElementsByTagName("text")[3].InnerText = _Message[2];       // Row:2 Col:1
                    _tileXml.GetElementsByTagName("text")[4].InnerText = _Message[3];       // Row:2 Col:2
                    _tileXml.GetElementsByTagName("text")[5].InnerText = _Message[4];       // Row:3 Col:1
                    _tileXml.GetElementsByTagName("text")[6].InnerText = _Message[5];       // Row:3 Col:2
                    _tileXml.GetElementsByTagName("text")[7].InnerText = _Message[6];       // Row:4 Col:1
                    _tileXml.GetElementsByTagName("text")[8].InnerText = _Message[7];       // Row:4 Col:2
#endif
                    break;
                case TileTemplateType.TileWideText03:
                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Title;
                    break;
                case TileTemplateType.TileWideText04:
                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Message[0];
                    break;
                case TileTemplateType.TileWideText05:
                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Message[0];
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[1];
                    _tileXml.GetElementsByTagName("text")[2].InnerText = _Message[2];
                    _tileXml.GetElementsByTagName("text")[3].InnerText = _Message[3];
                    _tileXml.GetElementsByTagName("text")[4].InnerText = _Message[4];
                    break;
                case TileTemplateType.TileWideText06:
#if WINDOWS_APP
                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Message[0];       // Row:1 Col:1
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[1];       // Row:1 Col:2
                    _tileXml.GetElementsByTagName("text")[2].InnerText = _Message[2];       // Row:2 Col:1
                    _tileXml.GetElementsByTagName("text")[3].InnerText = _Message[3];       // Row:2 Col:2
                    _tileXml.GetElementsByTagName("text")[4].InnerText = _Message[4];       // Row:3 Col:1
                    _tileXml.GetElementsByTagName("text")[5].InnerText = _Message[5];       // Row:3 Col:2
                    _tileXml.GetElementsByTagName("text")[6].InnerText = _Message[6];       // Row:4 Col:1
                    _tileXml.GetElementsByTagName("text")[7].InnerText = _Message[7];       // Row:4 Col:2
                    _tileXml.GetElementsByTagName("text")[8].InnerText = _Message[8];       // Row:5 Col:1
                    _tileXml.GetElementsByTagName("text")[9].InnerText = _Message[9];       // Row:5 Col:2
#endif
                    break;
                case TileTemplateType.TileWideText07:
#if WINDOWS_APP
                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Title;
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[0];       // Row:1 Col:1
                    _tileXml.GetElementsByTagName("text")[2].InnerText = _Message[1];       // Row:1 Col:2
                    _tileXml.GetElementsByTagName("text")[3].InnerText = _Message[2];       // Row:2 Col:1
                    _tileXml.GetElementsByTagName("text")[4].InnerText = _Message[3];       // Row:2 Col:2
                    _tileXml.GetElementsByTagName("text")[5].InnerText = _Message[4];       // Row:3 Col:1
                    _tileXml.GetElementsByTagName("text")[6].InnerText = _Message[5];       // Row:3 Col:2
                    _tileXml.GetElementsByTagName("text")[7].InnerText = _Message[6];       // Row:4 Col:1
                    _tileXml.GetElementsByTagName("text")[8].InnerText = _Message[7];       // Row:4 Col:2
#endif
                    break;
                case TileTemplateType.TileWideText08:
#if WINDOWS_APP
                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Message[0];       // Row:1 Col:1
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[1];       // Row:1 Col:2
                    _tileXml.GetElementsByTagName("text")[2].InnerText = _Message[2];       // Row:2 Col:1
                    _tileXml.GetElementsByTagName("text")[3].InnerText = _Message[3];       // Row:2 Col:2
                    _tileXml.GetElementsByTagName("text")[4].InnerText = _Message[4];       // Row:3 Col:1
                    _tileXml.GetElementsByTagName("text")[5].InnerText = _Message[5];       // Row:3 Col:2
                    _tileXml.GetElementsByTagName("text")[6].InnerText = _Message[6];       // Row:4 Col:1
                    _tileXml.GetElementsByTagName("text")[7].InnerText = _Message[7];       // Row:4 Col:2
                    _tileXml.GetElementsByTagName("text")[8].InnerText = _Message[8];       // Row:5 Col:1
                    _tileXml.GetElementsByTagName("text")[9].InnerText = _Message[9];       // Row:5 Col:2
#endif
                    break;
                case TileTemplateType.TileWideText09:
                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Title;
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[0];
                    break;
                case TileTemplateType.TileWideText10:
#if WINDOWS_APP
                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Title;
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[0];       // Row:1 Col:1
                    _tileXml.GetElementsByTagName("text")[2].InnerText = _Message[1];       // Row:1 Col:2
                    _tileXml.GetElementsByTagName("text")[3].InnerText = _Message[2];       // Row:2 Col:1
                    _tileXml.GetElementsByTagName("text")[4].InnerText = _Message[3];       // Row:2 Col:2
                    _tileXml.GetElementsByTagName("text")[5].InnerText = _Message[4];       // Row:3 Col:1
                    _tileXml.GetElementsByTagName("text")[6].InnerText = _Message[5];       // Row:3 Col:2
                    _tileXml.GetElementsByTagName("text")[7].InnerText = _Message[6];       // Row:4 Col:1
                    _tileXml.GetElementsByTagName("text")[8].InnerText = _Message[7];       // Row:4 Col:2
#endif
                    break;
                case TileTemplateType.TileWideText11:
#if WINDOWS_APP
                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Message[0];       // Row:1 Col:1
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[1];       // Row:1 Col:2
                    _tileXml.GetElementsByTagName("text")[2].InnerText = _Message[2];       // Row:2 Col:1
                    _tileXml.GetElementsByTagName("text")[3].InnerText = _Message[3];       // Row:2 Col:2
                    _tileXml.GetElementsByTagName("text")[4].InnerText = _Message[4];       // Row:3 Col:1
                    _tileXml.GetElementsByTagName("text")[5].InnerText = _Message[5];       // Row:3 Col:2
                    _tileXml.GetElementsByTagName("text")[6].InnerText = _Message[6];       // Row:4 Col:1
                    _tileXml.GetElementsByTagName("text")[7].InnerText = _Message[7];       // Row:4 Col:2
                    _tileXml.GetElementsByTagName("text")[8].InnerText = _Message[8];       // Row:5 Col:1
                    _tileXml.GetElementsByTagName("text")[9].InnerText = _Message[9];       // Row:5 Col:2
#endif
                    break;
                default:
#if WINDOWS_APP
#endif
#if WINDOWS_PHONE_APP
#endif
                    break;
            }
        }
        public void Set_Xml2(ref Windows.Data.Xml.Dom.XmlDocument _tileXml)
        {   // For [Windows8.1]
            XmlNodeList xnl;

            switch (_TType)
            {
                case TileTemplateType.TileSquare150x150Image:
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"alt text");
                    break;
                case TileTemplateType.TileSquare150x150Block:
                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Title;
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[0];
                    break;
                case TileTemplateType.TileSquare150x150Text01:
                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Title;
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[0];
                    _tileXml.GetElementsByTagName("text")[2].InnerText = _Message[1];
                    _tileXml.GetElementsByTagName("text")[3].InnerText = _Message[2];
                    break;
                case TileTemplateType.TileSquare150x150Text02:
                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Title;
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[0];
                    break;
                case TileTemplateType.TileSquare150x150Text03:
                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Message[0];
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[1];
                    _tileXml.GetElementsByTagName("text")[2].InnerText = _Message[2];
                    _tileXml.GetElementsByTagName("text")[3].InnerText = _Message[3];
                    break;
                case TileTemplateType.TileSquare150x150Text04:
                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Message[0];
                    break;
                case TileTemplateType.TileSquare150x150PeekImageAndText01:
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"alt text");
                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Title;
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[0];
                    _tileXml.GetElementsByTagName("text")[2].InnerText = _Message[1];
                    _tileXml.GetElementsByTagName("text")[3].InnerText = _Message[2];
                    break;
                case TileTemplateType.TileSquare150x150PeekImageAndText02:
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"alt text");
                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Title;
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[0];
                    break;
                case TileTemplateType.TileSquare150x150PeekImageAndText03:
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"alt text");
                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Message[0];
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[1];
                    _tileXml.GetElementsByTagName("text")[2].InnerText = _Message[2];
                    _tileXml.GetElementsByTagName("text")[3].InnerText = _Message[3];
                    break;
                case TileTemplateType.TileSquare150x150PeekImageAndText04:
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"alt text");
                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Message[0];
                    break;
                case TileTemplateType.TileWide310x150Image:
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"alt text");
                    break;
                case TileTemplateType.TileWide310x150ImageCollection:
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"larger image");

                    ((XmlElement)xnl[1]).SetAttribute("src", _Image[1]);
                    ((XmlElement)xnl[1]).SetAttribute("alt", @"small image, row 1, column 1");

                    ((XmlElement)xnl[2]).SetAttribute("src", _Image[2]);
                    ((XmlElement)xnl[2]).SetAttribute("alt", @"small image, row 1, column 2");

                    ((XmlElement)xnl[3]).SetAttribute("src", _Image[3]);
                    ((XmlElement)xnl[3]).SetAttribute("alt", @"small image, row 2, column 1");

                    ((XmlElement)xnl[4]).SetAttribute("src", _Image[4]);
                    ((XmlElement)xnl[4]).SetAttribute("alt", @"small image, row 2, column 2");
                    break;
                case TileTemplateType.TileWide310x150ImageAndText01:
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"alt text");

                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Message[0];
                    break;
                case TileTemplateType.TileWide310x150ImageAndText02:
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"alt text");

                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Message[0];
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[1];
                    break;
                case TileTemplateType.TileWide310x150BlockAndText01:
                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Message[0];
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[1];
                    _tileXml.GetElementsByTagName("text")[2].InnerText = _Message[2];
                    _tileXml.GetElementsByTagName("text")[3].InnerText = _Message[3];
                    _tileXml.GetElementsByTagName("text")[4].InnerText = _Title;
                    _tileXml.GetElementsByTagName("text")[5].InnerText = _SubTitle[0];
                    break;
                case TileTemplateType.TileWide310x150BlockAndText02:
                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Message[0];
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Title;
                    _tileXml.GetElementsByTagName("text")[2].InnerText = _SubTitle[0];
                    break;
                case TileTemplateType.TileWide310x150PeekImageCollection01:
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"larger image");
                    ((XmlElement)xnl[1]).SetAttribute("src", _Image[1]);
                    ((XmlElement)xnl[1]).SetAttribute("alt", @"small image, row 1, column 1");
                    ((XmlElement)xnl[2]).SetAttribute("src", _Image[2]);
                    ((XmlElement)xnl[2]).SetAttribute("alt", @"small image, row 1, column 2");
                    ((XmlElement)xnl[3]).SetAttribute("src", _Image[3]);
                    ((XmlElement)xnl[3]).SetAttribute("alt", @"small image, row 2, column 1");
                    ((XmlElement)xnl[4]).SetAttribute("src", _Image[4]);
                    ((XmlElement)xnl[4]).SetAttribute("alt", @"small image, row 2, column 2");

                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Title;
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[0];
                    break;
                case TileTemplateType.TileWide310x150PeekImageCollection02:
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"larger image");
                    ((XmlElement)xnl[1]).SetAttribute("src", _Image[1]);
                    ((XmlElement)xnl[1]).SetAttribute("alt", @"small image, row 1, column 1");
                    ((XmlElement)xnl[2]).SetAttribute("src", _Image[2]);
                    ((XmlElement)xnl[2]).SetAttribute("alt", @"small image, row 1, column 2");
                    ((XmlElement)xnl[3]).SetAttribute("src", _Image[3]);
                    ((XmlElement)xnl[3]).SetAttribute("alt", @"small image, row 2, column 1");
                    ((XmlElement)xnl[4]).SetAttribute("src", _Image[4]);
                    ((XmlElement)xnl[4]).SetAttribute("alt", @"small image, row 2, column 2");

                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Title;
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[0];
                    _tileXml.GetElementsByTagName("text")[2].InnerText = _Message[1];
                    _tileXml.GetElementsByTagName("text")[3].InnerText = _Message[2];
                    _tileXml.GetElementsByTagName("text")[4].InnerText = _Message[3];
                    break;
                case TileTemplateType.TileWide310x150PeekImageCollection03:
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"larger image");
                    ((XmlElement)xnl[1]).SetAttribute("src", _Image[1]);
                    ((XmlElement)xnl[1]).SetAttribute("alt", @"small image, row 1, column 1");
                    ((XmlElement)xnl[2]).SetAttribute("src", _Image[2]);
                    ((XmlElement)xnl[2]).SetAttribute("alt", @"small image, row 1, column 2");
                    ((XmlElement)xnl[3]).SetAttribute("src", _Image[3]);
                    ((XmlElement)xnl[3]).SetAttribute("alt", @"small image, row 2, column 1");
                    ((XmlElement)xnl[4]).SetAttribute("src", _Image[4]);
                    ((XmlElement)xnl[4]).SetAttribute("alt", @"small image, row 2, column 2");

                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Message[0];
                    break;
                case TileTemplateType.TileWide310x150PeekImageCollection04:
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"larger image");
                    ((XmlElement)xnl[1]).SetAttribute("src", _Image[1]);
                    ((XmlElement)xnl[1]).SetAttribute("alt", @"small image, row 1, column 1");
                    ((XmlElement)xnl[2]).SetAttribute("src", _Image[2]);
                    ((XmlElement)xnl[2]).SetAttribute("alt", @"small image, row 1, column 2");
                    ((XmlElement)xnl[3]).SetAttribute("src", _Image[3]);
                    ((XmlElement)xnl[3]).SetAttribute("alt", @"small image, row 2, column 1");
                    ((XmlElement)xnl[4]).SetAttribute("src", _Image[4]);
                    ((XmlElement)xnl[4]).SetAttribute("alt", @"small image, row 2, column 2");

                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Message[0];
                    break;
                case TileTemplateType.TileWide310x150PeekImageCollection05:
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"larger image");
                    ((XmlElement)xnl[1]).SetAttribute("src", _Image[1]);
                    ((XmlElement)xnl[1]).SetAttribute("alt", @"small image, row 1, column 1");
                    ((XmlElement)xnl[2]).SetAttribute("src", _Image[2]);
                    ((XmlElement)xnl[2]).SetAttribute("alt", @"small image, row 1, column 2");
                    ((XmlElement)xnl[3]).SetAttribute("src", _Image[3]);
                    ((XmlElement)xnl[3]).SetAttribute("alt", @"small image, row 2, column 1");
                    ((XmlElement)xnl[4]).SetAttribute("src", _Image[4]);
                    ((XmlElement)xnl[4]).SetAttribute("alt", @"small image, row 2, column 2");
                    ((XmlElement)xnl[5]).SetAttribute("src", _Image[5]);
                    ((XmlElement)xnl[5]).SetAttribute("alt", @"image next to text");

                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Title;
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[0];
                    break;
                case TileTemplateType.TileWide310x150PeekImageCollection06:
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"larger image");
                    ((XmlElement)xnl[1]).SetAttribute("src", _Image[1]);
                    ((XmlElement)xnl[1]).SetAttribute("alt", @"small image, row 1, column 1");
                    ((XmlElement)xnl[2]).SetAttribute("src", _Image[2]);
                    ((XmlElement)xnl[2]).SetAttribute("alt", @"small image, row 1, column 2");
                    ((XmlElement)xnl[3]).SetAttribute("src", _Image[3]);
                    ((XmlElement)xnl[3]).SetAttribute("alt", @"small image, row 2, column 1");
                    ((XmlElement)xnl[4]).SetAttribute("src", _Image[4]);
                    ((XmlElement)xnl[4]).SetAttribute("alt", @"small image, row 2, column 2");
                    ((XmlElement)xnl[5]).SetAttribute("src", _Image[5]);
                    ((XmlElement)xnl[5]).SetAttribute("alt", @"image next to text");

                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Message[0];
                    break;
                case TileTemplateType.TileWide310x150PeekImageAndText01:
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"alt text");

                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Message[0];
                    break;
                case TileTemplateType.TileWide310x150PeekImageAndText02:
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"alt text");

                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Message[0];
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[1];
                    _tileXml.GetElementsByTagName("text")[2].InnerText = _Message[2];
                    _tileXml.GetElementsByTagName("text")[3].InnerText = _Message[3];
                    _tileXml.GetElementsByTagName("text")[4].InnerText = _Message[4];
                    break;
                case TileTemplateType.TileWide310x150PeekImage01:
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"alt text");

                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Title;
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[0];
                    break;
                case TileTemplateType.TileWide310x150PeekImage02:
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"alt text");

                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Title;
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[0];
                    _tileXml.GetElementsByTagName("text")[2].InnerText = _Message[1];
                    _tileXml.GetElementsByTagName("text")[3].InnerText = _Message[2];
                    _tileXml.GetElementsByTagName("text")[4].InnerText = _Message[3];
                    break;
                case TileTemplateType.TileWide310x150PeekImage03:
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"alt text");

                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Message[0];
                    break;
                case TileTemplateType.TileWide310x150PeekImage04:
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"alt text");

                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Message[0];
                    break;
                case TileTemplateType.TileWide310x150PeekImage05:
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"main image");
                    ((XmlElement)xnl[1]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[1]).SetAttribute("alt", @"smaller image next to text");

                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Title;
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[0];
                    break;
                case TileTemplateType.TileWide310x150PeekImage06:
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"main image");
                    ((XmlElement)xnl[1]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[1]).SetAttribute("alt", @"smaller image next to text");

                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Message[0];
                    break;
                case TileTemplateType.TileWide310x150SmallImageAndText01:
#if WINDOWS_APP
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"alt text");
#endif

                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Message[0];
                    break;
                case TileTemplateType.TileWide310x150SmallImageAndText02:
#if WINDOWS_APP
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"alt text");
#endif

                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Title;
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[0];
                    _tileXml.GetElementsByTagName("text")[2].InnerText = _Message[1];
                    _tileXml.GetElementsByTagName("text")[3].InnerText = _Message[2];
                    _tileXml.GetElementsByTagName("text")[4].InnerText = _Message[3];
                    break;
                case TileTemplateType.TileWide310x150SmallImageAndText03:
#if WINDOWS_APP
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"alt text");
#endif

                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Message[0];
                    break;
                case TileTemplateType.TileWide310x150SmallImageAndText04:
#if WINDOWS_APP
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"alt text");
#endif

                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Title;
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[0];
                    break;
                case TileTemplateType.TileWide310x150SmallImageAndText05:
#if WINDOWS_APP
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"alt text");
#endif

                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Title;
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[0];
                    break;
                case TileTemplateType.TileWide310x150Text01:
                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Title;
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[0];
                    _tileXml.GetElementsByTagName("text")[2].InnerText = _Message[1];
                    _tileXml.GetElementsByTagName("text")[3].InnerText = _Message[2];
                    _tileXml.GetElementsByTagName("text")[4].InnerText = _Message[3];
                    break;
                case TileTemplateType.TileWide310x150Text02:
#if WINDOWS_APP
                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Title;
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[0];       // Row:1 Col:1
                    _tileXml.GetElementsByTagName("text")[2].InnerText = _Message[1];       // Row:1 Col:2
                    _tileXml.GetElementsByTagName("text")[3].InnerText = _Message[2];       // Row:2 Col:1
                    _tileXml.GetElementsByTagName("text")[4].InnerText = _Message[3];       // Row:2 Col:2
                    _tileXml.GetElementsByTagName("text")[5].InnerText = _Message[4];       // Row:3 Col:1
                    _tileXml.GetElementsByTagName("text")[6].InnerText = _Message[5];       // Row:3 Col:2
                    _tileXml.GetElementsByTagName("text")[7].InnerText = _Message[6];       // Row:4 Col:1
                    _tileXml.GetElementsByTagName("text")[8].InnerText = _Message[7];       // Row:4 Col:2
#endif
                    break;
                case TileTemplateType.TileWide310x150Text03:
                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Title;
                    break;
                case TileTemplateType.TileWide310x150Text04:
                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Message[0];
                    break;
                case TileTemplateType.TileWide310x150Text05:
                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Message[0];
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[1];
                    _tileXml.GetElementsByTagName("text")[2].InnerText = _Message[2];
                    _tileXml.GetElementsByTagName("text")[3].InnerText = _Message[3];
                    _tileXml.GetElementsByTagName("text")[4].InnerText = _Message[4];
                    break;
                case TileTemplateType.TileWide310x150Text06:
#if WINDOWS_APP
                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Message[0];       // Row:1 Col:1
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[1];       // Row:1 Col:2
                    _tileXml.GetElementsByTagName("text")[2].InnerText = _Message[2];       // Row:2 Col:1
                    _tileXml.GetElementsByTagName("text")[3].InnerText = _Message[3];       // Row:2 Col:2
                    _tileXml.GetElementsByTagName("text")[4].InnerText = _Message[4];       // Row:3 Col:1
                    _tileXml.GetElementsByTagName("text")[5].InnerText = _Message[5];       // Row:3 Col:2
                    _tileXml.GetElementsByTagName("text")[6].InnerText = _Message[6];       // Row:4 Col:1
                    _tileXml.GetElementsByTagName("text")[7].InnerText = _Message[7];       // Row:4 Col:2
                    _tileXml.GetElementsByTagName("text")[8].InnerText = _Message[8];       // Row:5 Col:1
                    _tileXml.GetElementsByTagName("text")[9].InnerText = _Message[9];       // Row:5 Col:2
#endif
                    break;
                case TileTemplateType.TileWide310x150Text07:
#if WINDOWS_APP
                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Title;
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[0];       // Row:1 Col:1
                    _tileXml.GetElementsByTagName("text")[2].InnerText = _Message[1];       // Row:1 Col:2
                    _tileXml.GetElementsByTagName("text")[3].InnerText = _Message[2];       // Row:2 Col:1
                    _tileXml.GetElementsByTagName("text")[4].InnerText = _Message[3];       // Row:2 Col:2
                    _tileXml.GetElementsByTagName("text")[5].InnerText = _Message[4];       // Row:3 Col:1
                    _tileXml.GetElementsByTagName("text")[6].InnerText = _Message[5];       // Row:3 Col:2
                    _tileXml.GetElementsByTagName("text")[7].InnerText = _Message[6];       // Row:4 Col:1
                    _tileXml.GetElementsByTagName("text")[8].InnerText = _Message[7];       // Row:4 Col:2
#endif
                    break;
                case TileTemplateType.TileWide310x150Text08:
#if WINDOWS_APP
                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Message[0];       // Row:1 Col:1
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[1];       // Row:1 Col:2
                    _tileXml.GetElementsByTagName("text")[2].InnerText = _Message[2];       // Row:2 Col:1
                    _tileXml.GetElementsByTagName("text")[3].InnerText = _Message[3];       // Row:2 Col:2
                    _tileXml.GetElementsByTagName("text")[4].InnerText = _Message[4];       // Row:3 Col:1
                    _tileXml.GetElementsByTagName("text")[5].InnerText = _Message[5];       // Row:3 Col:2
                    _tileXml.GetElementsByTagName("text")[6].InnerText = _Message[6];       // Row:4 Col:1
                    _tileXml.GetElementsByTagName("text")[7].InnerText = _Message[7];       // Row:4 Col:2
                    _tileXml.GetElementsByTagName("text")[8].InnerText = _Message[8];       // Row:5 Col:1
                    _tileXml.GetElementsByTagName("text")[9].InnerText = _Message[9];       // Row:5 Col:2
#endif
                    break;
                case TileTemplateType.TileWide310x150Text09:
                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Title;
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[0];
                    break;
                case TileTemplateType.TileWide310x150Text10:
#if WINDOWS_APP
                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Title;
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[0];       // Row:1 Col:1
                    _tileXml.GetElementsByTagName("text")[2].InnerText = _Message[1];       // Row:1 Col:2
                    _tileXml.GetElementsByTagName("text")[3].InnerText = _Message[2];       // Row:2 Col:1
                    _tileXml.GetElementsByTagName("text")[4].InnerText = _Message[3];       // Row:2 Col:2
                    _tileXml.GetElementsByTagName("text")[5].InnerText = _Message[4];       // Row:3 Col:1
                    _tileXml.GetElementsByTagName("text")[6].InnerText = _Message[5];       // Row:3 Col:2
                    _tileXml.GetElementsByTagName("text")[7].InnerText = _Message[6];       // Row:4 Col:1
                    _tileXml.GetElementsByTagName("text")[8].InnerText = _Message[7];       // Row:4 Col:2
#endif
                    break;
                case TileTemplateType.TileWide310x150Text11:
#if WINDOWS_APP
                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Message[0];       // Row:1 Col:1
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[1];       // Row:1 Col:2
                    _tileXml.GetElementsByTagName("text")[2].InnerText = _Message[2];       // Row:2 Col:1
                    _tileXml.GetElementsByTagName("text")[3].InnerText = _Message[3];       // Row:2 Col:2
                    _tileXml.GetElementsByTagName("text")[4].InnerText = _Message[4];       // Row:3 Col:1
                    _tileXml.GetElementsByTagName("text")[5].InnerText = _Message[5];       // Row:3 Col:2
                    _tileXml.GetElementsByTagName("text")[6].InnerText = _Message[6];       // Row:4 Col:1
                    _tileXml.GetElementsByTagName("text")[7].InnerText = _Message[7];       // Row:4 Col:2
                    _tileXml.GetElementsByTagName("text")[8].InnerText = _Message[8];       // Row:5 Col:1
                    _tileXml.GetElementsByTagName("text")[9].InnerText = _Message[9];       // Row:5 Col:2
#endif
                    break;
                case TileTemplateType.TileSquare310x310BlockAndText01:
#if WINDOWS_APP
                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Title;
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[0];
                    _tileXml.GetElementsByTagName("text")[2].InnerText = _Message[1];
                    _tileXml.GetElementsByTagName("text")[3].InnerText = _Message[2];
                    _tileXml.GetElementsByTagName("text")[4].InnerText = _Message[3];
                    _tileXml.GetElementsByTagName("text")[5].InnerText = _Message[4];
                    _tileXml.GetElementsByTagName("text")[6].InnerText = _Message[5];

                    _tileXml.GetElementsByTagName("text")[7].InnerText = _SubTitle[0];
                    _tileXml.GetElementsByTagName("text")[8].InnerText = _Message[6];
#endif
                    break;
                case TileTemplateType.TileSquare310x310BlockAndText02:
#if WINDOWS_APP
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"alt text");

                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Title;
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _SubTitle[0];
                    _tileXml.GetElementsByTagName("text")[2].InnerText = _SubTitle[1];
                    _tileXml.GetElementsByTagName("text")[3].InnerText = _Message[0];
                    _tileXml.GetElementsByTagName("text")[4].InnerText = _Message[1];
                    _tileXml.GetElementsByTagName("text")[5].InnerText = _Message[2];
                    _tileXml.GetElementsByTagName("text")[6].InnerText = _Message[3];
#endif
                    break;
                case TileTemplateType.TileSquare310x310Image:
#if WINDOWS_APP
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"alt text");
#endif
                    break;
                case TileTemplateType.TileSquare310x310ImageAndText01:
#if WINDOWS_APP
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"alt text");

                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Message[0];
#endif
                    break;
                case TileTemplateType.TileSquare310x310ImageAndText02:
#if WINDOWS_APP
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"alt text");

                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Message[0];
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[1];
#endif
                    break;
                case TileTemplateType.TileSquare310x310ImageAndTextOverlay01:
#if WINDOWS_APP
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"alt text");

                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Message[0];
#endif
                    break;
                case TileTemplateType.TileSquare310x310ImageAndTextOverlay02:
#if WINDOWS_APP
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"alt text");

                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Title;
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[0];
#endif
                    break;
                case TileTemplateType.TileSquare310x310ImageAndTextOverlay03:
#if WINDOWS_APP
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"alt text");

                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Title;
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[0];
                    _tileXml.GetElementsByTagName("text")[2].InnerText = _Message[1];
                    _tileXml.GetElementsByTagName("text")[3].InnerText = _Message[2];
#endif
                    break;
                case TileTemplateType.TileSquare310x310ImageCollectionAndText01:
#if WINDOWS_APP
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"main image");
                    ((XmlElement)xnl[1]).SetAttribute("src", _Image[1]);
                    ((XmlElement)xnl[1]).SetAttribute("alt", @"small image 1 (left)");
                    ((XmlElement)xnl[2]).SetAttribute("src", _Image[2]);
                    ((XmlElement)xnl[2]).SetAttribute("alt", @"small image 2 (left center)");
                    ((XmlElement)xnl[3]).SetAttribute("src", _Image[3]);
                    ((XmlElement)xnl[3]).SetAttribute("alt", @"small image 3 (right center)");
                    ((XmlElement)xnl[4]).SetAttribute("src", _Image[4]);
                    ((XmlElement)xnl[4]).SetAttribute("alt", @"small image 4 (right)");

                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Message[0];
#endif
                    break;
                case TileTemplateType.TileSquare310x310ImageCollectionAndText02:
#if WINDOWS_APP
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"main image");
                    ((XmlElement)xnl[1]).SetAttribute("src", _Image[1]);
                    ((XmlElement)xnl[1]).SetAttribute("alt", @"small image 1 (left)");
                    ((XmlElement)xnl[2]).SetAttribute("src", _Image[2]);
                    ((XmlElement)xnl[2]).SetAttribute("alt", @"small image 2 (left center)");
                    ((XmlElement)xnl[3]).SetAttribute("src", _Image[3]);
                    ((XmlElement)xnl[3]).SetAttribute("alt", @"small image 3 (right center)");
                    ((XmlElement)xnl[4]).SetAttribute("src", _Image[4]);
                    ((XmlElement)xnl[4]).SetAttribute("alt", @"small image 4 (right)");

                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Message[0];
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[2];
#endif
                    break;
                case TileTemplateType.TileSquare310x310ImageCollection:
#if WINDOWS_APP
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"main image");
                    ((XmlElement)xnl[1]).SetAttribute("src", _Image[1]);
                    ((XmlElement)xnl[1]).SetAttribute("alt", @"small image 1 (left)");
                    ((XmlElement)xnl[2]).SetAttribute("src", _Image[2]);
                    ((XmlElement)xnl[2]).SetAttribute("alt", @"small image 2 (left center)");
                    ((XmlElement)xnl[3]).SetAttribute("src", _Image[3]);
                    ((XmlElement)xnl[3]).SetAttribute("alt", @"small image 3 (right center)");
                    ((XmlElement)xnl[4]).SetAttribute("src", _Image[4]);
                    ((XmlElement)xnl[4]).SetAttribute("alt", @"small image 4 (right)");
#endif
                    break;
                case TileTemplateType.TileSquare310x310SmallImagesAndTextList01:
#if WINDOWS_APP
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"alt text");
                    ((XmlElement)xnl[1]).SetAttribute("src", _Image[1]);
                    ((XmlElement)xnl[1]).SetAttribute("alt", @"alt text");
                    ((XmlElement)xnl[2]).SetAttribute("src", _Image[2]);
                    ((XmlElement)xnl[2]).SetAttribute("alt", @"alt text");

                    _tileXml.GetElementsByTagName("text")[0].InnerText = _SubTitle[0];
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[0];
                    _tileXml.GetElementsByTagName("text")[2].InnerText = _Message[1];
                    _tileXml.GetElementsByTagName("text")[3].InnerText = _SubTitle[1];
                    _tileXml.GetElementsByTagName("text")[4].InnerText = _Message[2];
                    _tileXml.GetElementsByTagName("text")[5].InnerText = _Message[3];
                    _tileXml.GetElementsByTagName("text")[6].InnerText = _SubTitle[2];
                    _tileXml.GetElementsByTagName("text")[7].InnerText = _Message[4];
                    _tileXml.GetElementsByTagName("text")[8].InnerText = _Message[5];
#endif
                    break;
                case TileTemplateType.TileSquare310x310SmallImagesAndTextList02:
#if WINDOWS_APP
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"alt text");
                    ((XmlElement)xnl[1]).SetAttribute("src", _Image[1]);
                    ((XmlElement)xnl[1]).SetAttribute("alt", @"alt text");
                    ((XmlElement)xnl[2]).SetAttribute("src", _Image[2]);
                    ((XmlElement)xnl[2]).SetAttribute("alt", @"alt text");

                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Message[0];
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[1];
                    _tileXml.GetElementsByTagName("text")[2].InnerText = _Message[2];
#endif
                    break;
                case TileTemplateType.TileSquare310x310SmallImagesAndTextList03:
#if WINDOWS_APP
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"alt text");
                    ((XmlElement)xnl[1]).SetAttribute("src", _Image[1]);
                    ((XmlElement)xnl[1]).SetAttribute("alt", @"alt text");
                    ((XmlElement)xnl[2]).SetAttribute("src", _Image[2]);
                    ((XmlElement)xnl[2]).SetAttribute("alt", @"alt text");

                    _tileXml.GetElementsByTagName("text")[0].InnerText = _SubTitle[0];
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[0];
                    _tileXml.GetElementsByTagName("text")[2].InnerText = _SubTitle[1];
                    _tileXml.GetElementsByTagName("text")[3].InnerText = _Message[1];
                    _tileXml.GetElementsByTagName("text")[4].InnerText = _SubTitle[2];
                    _tileXml.GetElementsByTagName("text")[5].InnerText = _Message[2];
#endif
                    break;
                case TileTemplateType.TileSquare310x310SmallImagesAndTextList04:
#if WINDOWS_APP
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"alt text");
                    ((XmlElement)xnl[1]).SetAttribute("src", _Image[1]);
                    ((XmlElement)xnl[1]).SetAttribute("alt", @"alt text");
                    ((XmlElement)xnl[2]).SetAttribute("src", _Image[2]);
                    ((XmlElement)xnl[2]).SetAttribute("alt", @"alt text");

                    _tileXml.GetElementsByTagName("text")[0].InnerText = _SubTitle[0];
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[0];
                    _tileXml.GetElementsByTagName("text")[2].InnerText = _SubTitle[1];
                    _tileXml.GetElementsByTagName("text")[3].InnerText = _Message[1];
                    _tileXml.GetElementsByTagName("text")[4].InnerText = _SubTitle[2];
                    _tileXml.GetElementsByTagName("text")[5].InnerText = _Message[2];
#endif
                    break;
                case TileTemplateType.TileSquare310x310SmallImagesAndTextList05:
#if WINDOWS_APP
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"alt text");
                    ((XmlElement)xnl[1]).SetAttribute("src", _Image[1]);
                    ((XmlElement)xnl[1]).SetAttribute("alt", @"alt text");
                    ((XmlElement)xnl[2]).SetAttribute("src", _Image[2]);
                    ((XmlElement)xnl[2]).SetAttribute("alt", @"alt text");

                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Title;
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[0];
                    _tileXml.GetElementsByTagName("text")[2].InnerText = _Message[1];
                    _tileXml.GetElementsByTagName("text")[3].InnerText = _Message[2];
                    _tileXml.GetElementsByTagName("text")[4].InnerText = _Message[3];
                    _tileXml.GetElementsByTagName("text")[5].InnerText = _Message[4];
                    _tileXml.GetElementsByTagName("text")[6].InnerText = _Message[5];
#endif
                    break;
                case TileTemplateType.TileSquare310x310SmallImageAndText01:
#if WINDOWS_APP
                    xnl = _tileXml.GetElementsByTagName("image");
                    ((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
                    ((XmlElement)xnl[0]).SetAttribute("alt", @"alt text");

                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Title;
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[0];
                    _tileXml.GetElementsByTagName("text")[2].InnerText = _Message[1];
#endif
                    break;
                case TileTemplateType.TileSquare310x310Text01:
#if WINDOWS_APP
                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Title;
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[0];
                    _tileXml.GetElementsByTagName("text")[2].InnerText = _Message[1];
                    _tileXml.GetElementsByTagName("text")[3].InnerText = _Message[2];
                    _tileXml.GetElementsByTagName("text")[4].InnerText = _Message[3];
                    _tileXml.GetElementsByTagName("text")[5].InnerText = _Message[4];
                    _tileXml.GetElementsByTagName("text")[6].InnerText = _Message[5];
                    _tileXml.GetElementsByTagName("text")[7].InnerText = _Message[6];
                    _tileXml.GetElementsByTagName("text")[8].InnerText = _Message[7];
                    _tileXml.GetElementsByTagName("text")[9].InnerText = _Message[8];
#endif
                    break;
                case TileTemplateType.TileSquare310x310Text02:
#if WINDOWS_APP
                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Title;
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[0];       // Row:1 Col:1
                    _tileXml.GetElementsByTagName("text")[2].InnerText = _Message[1];       // Row:1 Col:2
                    _tileXml.GetElementsByTagName("text")[3].InnerText = _Message[2];       // Row:2 Col:1
                    _tileXml.GetElementsByTagName("text")[4].InnerText = _Message[3];       // Row:2 Col:2
                    _tileXml.GetElementsByTagName("text")[5].InnerText = _Message[4];       // Row:3 Col:1
                    _tileXml.GetElementsByTagName("text")[6].InnerText = _Message[5];       // Row:3 Col:2
                    _tileXml.GetElementsByTagName("text")[7].InnerText = _Message[6];       // Row:4 Col:1
                    _tileXml.GetElementsByTagName("text")[8].InnerText = _Message[7];       // Row:4 Col:2
                    _tileXml.GetElementsByTagName("text")[9].InnerText = _Message[8];       // Row:5 Col:1
                    _tileXml.GetElementsByTagName("text")[10].InnerText = _Message[9];      // Row:5 Col:2
                    _tileXml.GetElementsByTagName("text")[11].InnerText = _Message[10];     // Row:6 Col:1
                    _tileXml.GetElementsByTagName("text")[12].InnerText = _Message[11];     // Row:6 Col:2
                    _tileXml.GetElementsByTagName("text")[13].InnerText = _Message[12];     // Row:7 Col:1
                    _tileXml.GetElementsByTagName("text")[14].InnerText = _Message[13];     // Row:7 Col:2
                    _tileXml.GetElementsByTagName("text")[15].InnerText = _Message[14];     // Row:8 Col:1
                    _tileXml.GetElementsByTagName("text")[16].InnerText = _Message[15];     // Row:8 Col:2
                    _tileXml.GetElementsByTagName("text")[17].InnerText = _Message[16];     // Row:9 Col:1
                    _tileXml.GetElementsByTagName("text")[18].InnerText = _Message[17];     // Row:9 Col:2
#endif
                    break;
                case TileTemplateType.TileSquare310x310Text03:
#if WINDOWS_APP
                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Message[0];
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[1];
                    _tileXml.GetElementsByTagName("text")[2].InnerText = _Message[2];
                    _tileXml.GetElementsByTagName("text")[3].InnerText = _Message[3];
                    _tileXml.GetElementsByTagName("text")[4].InnerText = _Message[4];
                    _tileXml.GetElementsByTagName("text")[5].InnerText = _Message[5];
                    _tileXml.GetElementsByTagName("text")[6].InnerText = _Message[6];
                    _tileXml.GetElementsByTagName("text")[7].InnerText = _Message[7];
                    _tileXml.GetElementsByTagName("text")[8].InnerText = _Message[8];
                    _tileXml.GetElementsByTagName("text")[9].InnerText = _Message[9];
                    _tileXml.GetElementsByTagName("text")[10].InnerText = _Message[10];
#endif
                    break;
                case TileTemplateType.TileSquare310x310Text04:
#if WINDOWS_APP
                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Message[0];       // Row:1 Col:1
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[1];       // Row:1 Col:2
                    _tileXml.GetElementsByTagName("text")[2].InnerText = _Message[2];       // Row:2 Col:1
                    _tileXml.GetElementsByTagName("text")[3].InnerText = _Message[3];       // Row:2 Col:2
                    _tileXml.GetElementsByTagName("text")[4].InnerText = _Message[4];       // Row:3 Col:1
                    _tileXml.GetElementsByTagName("text")[5].InnerText = _Message[5];       // Row:3 Col:2
                    _tileXml.GetElementsByTagName("text")[6].InnerText = _Message[6];       // Row:4 Col:1
                    _tileXml.GetElementsByTagName("text")[7].InnerText = _Message[7];       // Row:4 Col:2
                    _tileXml.GetElementsByTagName("text")[8].InnerText = _Message[8];       // Row:5 Col:1
                    _tileXml.GetElementsByTagName("text")[9].InnerText = _Message[9];       // Row:5 Col:2
                    _tileXml.GetElementsByTagName("text")[10].InnerText = _Message[10];     // Row:6 Col:1
                    _tileXml.GetElementsByTagName("text")[11].InnerText = _Message[11];     // Row:6 Col:2
                    _tileXml.GetElementsByTagName("text")[12].InnerText = _Message[12];     // Row:7 Col:1
                    _tileXml.GetElementsByTagName("text")[13].InnerText = _Message[13];     // Row:7 Col:2
                    _tileXml.GetElementsByTagName("text")[14].InnerText = _Message[14];     // Row:8 Col:1
                    _tileXml.GetElementsByTagName("text")[15].InnerText = _Message[15];     // Row:8 Col:2
                    _tileXml.GetElementsByTagName("text")[16].InnerText = _Message[16];     // Row:9 Col:1
                    _tileXml.GetElementsByTagName("text")[17].InnerText = _Message[17];     // Row:9 Col:2
                    _tileXml.GetElementsByTagName("text")[18].InnerText = _Message[18];     // Row:10 Col:1
                    _tileXml.GetElementsByTagName("text")[19].InnerText = _Message[19];     // Row:10 Col:2
                    _tileXml.GetElementsByTagName("text")[20].InnerText = _Message[20];     // Row:11 Col:1
                    _tileXml.GetElementsByTagName("text")[21].InnerText = _Message[21];     // Row:11 Col:2
#endif
                    break;
                case TileTemplateType.TileSquare310x310Text05:
#if WINDOWS_APP
                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Title;
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[0];       // Row:1 Col:1
                    _tileXml.GetElementsByTagName("text")[2].InnerText = _Message[1];       // Row:1 Col:2
                    _tileXml.GetElementsByTagName("text")[3].InnerText = _Message[2];       // Row:2 Col:1
                    _tileXml.GetElementsByTagName("text")[4].InnerText = _Message[3];       // Row:2 Col:2
                    _tileXml.GetElementsByTagName("text")[5].InnerText = _Message[4];       // Row:3 Col:1
                    _tileXml.GetElementsByTagName("text")[6].InnerText = _Message[5];       // Row:3 Col:2
                    _tileXml.GetElementsByTagName("text")[7].InnerText = _Message[6];       // Row:4 Col:1
                    _tileXml.GetElementsByTagName("text")[8].InnerText = _Message[7];       // Row:4 Col:2
                    _tileXml.GetElementsByTagName("text")[9].InnerText = _Message[8];       // Row:5 Col:1
                    _tileXml.GetElementsByTagName("text")[10].InnerText = _Message[9];      // Row:5 Col:2
                    _tileXml.GetElementsByTagName("text")[11].InnerText = _Message[10];     // Row:6 Col:1
                    _tileXml.GetElementsByTagName("text")[12].InnerText = _Message[11];     // Row:6 Col:2
                    _tileXml.GetElementsByTagName("text")[13].InnerText = _Message[12];     // Row:7 Col:1
                    _tileXml.GetElementsByTagName("text")[14].InnerText = _Message[13];     // Row:7 Col:2
                    _tileXml.GetElementsByTagName("text")[15].InnerText = _Message[14];     // Row:8 Col:1
                    _tileXml.GetElementsByTagName("text")[16].InnerText = _Message[15];     // Row:8 Col:2
                    _tileXml.GetElementsByTagName("text")[17].InnerText = _Message[16];     // Row:9 Col:1
                    _tileXml.GetElementsByTagName("text")[18].InnerText = _Message[17];     // Row:9 Col:2
#endif
                    break;
                case TileTemplateType.TileSquare310x310Text06:
#if WINDOWS_APP
                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Message[0];       // Row:1 Col:1
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[1];       // Row:1 Col:2
                    _tileXml.GetElementsByTagName("text")[2].InnerText = _Message[2];       // Row:2 Col:1
                    _tileXml.GetElementsByTagName("text")[3].InnerText = _Message[3];       // Row:2 Col:2
                    _tileXml.GetElementsByTagName("text")[4].InnerText = _Message[4];       // Row:3 Col:1
                    _tileXml.GetElementsByTagName("text")[5].InnerText = _Message[5];       // Row:3 Col:2
                    _tileXml.GetElementsByTagName("text")[6].InnerText = _Message[6];       // Row:4 Col:1
                    _tileXml.GetElementsByTagName("text")[7].InnerText = _Message[7];       // Row:4 Col:2
                    _tileXml.GetElementsByTagName("text")[8].InnerText = _Message[8];       // Row:5 Col:1
                    _tileXml.GetElementsByTagName("text")[9].InnerText = _Message[9];       // Row:5 Col:2
                    _tileXml.GetElementsByTagName("text")[10].InnerText = _Message[10];     // Row:6 Col:1
                    _tileXml.GetElementsByTagName("text")[11].InnerText = _Message[11];     // Row:6 Col:2
                    _tileXml.GetElementsByTagName("text")[12].InnerText = _Message[12];     // Row:7 Col:1
                    _tileXml.GetElementsByTagName("text")[13].InnerText = _Message[13];     // Row:7 Col:2
                    _tileXml.GetElementsByTagName("text")[14].InnerText = _Message[14];     // Row:8 Col:1
                    _tileXml.GetElementsByTagName("text")[15].InnerText = _Message[15];     // Row:8 Col:2
                    _tileXml.GetElementsByTagName("text")[16].InnerText = _Message[16];     // Row:9 Col:1
                    _tileXml.GetElementsByTagName("text")[17].InnerText = _Message[17];     // Row:9 Col:2
                    _tileXml.GetElementsByTagName("text")[18].InnerText = _Message[18];     // Row:10 Col:1
                    _tileXml.GetElementsByTagName("text")[19].InnerText = _Message[19];     // Row:10 Col:2
                    _tileXml.GetElementsByTagName("text")[20].InnerText = _Message[20];     // Row:11 Col:1
                    _tileXml.GetElementsByTagName("text")[21].InnerText = _Message[21];     // Row:11 Col:2
#endif
                    break;
                case TileTemplateType.TileSquare310x310Text07:
#if WINDOWS_APP
                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Title;
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[0];       // Row:1 Col:1
                    _tileXml.GetElementsByTagName("text")[2].InnerText = _Message[1];       // Row:1 Col:2
                    _tileXml.GetElementsByTagName("text")[3].InnerText = _Message[2];       // Row:2 Col:1
                    _tileXml.GetElementsByTagName("text")[4].InnerText = _Message[3];       // Row:2 Col:2
                    _tileXml.GetElementsByTagName("text")[5].InnerText = _Message[4];       // Row:3 Col:1
                    _tileXml.GetElementsByTagName("text")[6].InnerText = _Message[5];       // Row:3 Col:2
                    _tileXml.GetElementsByTagName("text")[7].InnerText = _Message[6];       // Row:4 Col:1
                    _tileXml.GetElementsByTagName("text")[8].InnerText = _Message[7];       // Row:4 Col:2
                    _tileXml.GetElementsByTagName("text")[9].InnerText = _Message[8];       // Row:5 Col:1
                    _tileXml.GetElementsByTagName("text")[10].InnerText = _Message[9];      // Row:5 Col:2
                    _tileXml.GetElementsByTagName("text")[11].InnerText = _Message[10];     // Row:6 Col:1
                    _tileXml.GetElementsByTagName("text")[12].InnerText = _Message[11];     // Row:6 Col:2
                    _tileXml.GetElementsByTagName("text")[13].InnerText = _Message[12];     // Row:7 Col:1
                    _tileXml.GetElementsByTagName("text")[14].InnerText = _Message[13];     // Row:7 Col:2
                    _tileXml.GetElementsByTagName("text")[15].InnerText = _Message[14];     // Row:8 Col:1
                    _tileXml.GetElementsByTagName("text")[16].InnerText = _Message[15];     // Row:8 Col:2
                    _tileXml.GetElementsByTagName("text")[17].InnerText = _Message[16];     // Row:9 Col:1
                    _tileXml.GetElementsByTagName("text")[18].InnerText = _Message[17];     // Row:9 Col:2
#endif
                    break;
                case TileTemplateType.TileSquare310x310Text08:
#if WINDOWS_APP
                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Message[0];       // Row:1 Col:1
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[1];       // Row:1 Col:2
                    _tileXml.GetElementsByTagName("text")[2].InnerText = _Message[2];       // Row:2 Col:1
                    _tileXml.GetElementsByTagName("text")[3].InnerText = _Message[3];       // Row:2 Col:2
                    _tileXml.GetElementsByTagName("text")[4].InnerText = _Message[4];       // Row:3 Col:1
                    _tileXml.GetElementsByTagName("text")[5].InnerText = _Message[5];       // Row:3 Col:2
                    _tileXml.GetElementsByTagName("text")[6].InnerText = _Message[6];       // Row:4 Col:1
                    _tileXml.GetElementsByTagName("text")[7].InnerText = _Message[7];       // Row:4 Col:2
                    _tileXml.GetElementsByTagName("text")[8].InnerText = _Message[8];       // Row:5 Col:1
                    _tileXml.GetElementsByTagName("text")[9].InnerText = _Message[9];       // Row:5 Col:2
                    _tileXml.GetElementsByTagName("text")[10].InnerText = _Message[10];     // Row:6 Col:1
                    _tileXml.GetElementsByTagName("text")[11].InnerText = _Message[11];     // Row:6 Col:2
                    _tileXml.GetElementsByTagName("text")[12].InnerText = _Message[12];     // Row:7 Col:1
                    _tileXml.GetElementsByTagName("text")[13].InnerText = _Message[13];     // Row:7 Col:2
                    _tileXml.GetElementsByTagName("text")[14].InnerText = _Message[14];     // Row:8 Col:1
                    _tileXml.GetElementsByTagName("text")[15].InnerText = _Message[15];     // Row:8 Col:2
                    _tileXml.GetElementsByTagName("text")[16].InnerText = _Message[16];     // Row:9 Col:1
                    _tileXml.GetElementsByTagName("text")[17].InnerText = _Message[17];     // Row:9 Col:2
                    _tileXml.GetElementsByTagName("text")[18].InnerText = _Message[18];     // Row:10 Col:1
                    _tileXml.GetElementsByTagName("text")[19].InnerText = _Message[19];     // Row:10 Col:2
                    _tileXml.GetElementsByTagName("text")[20].InnerText = _Message[20];     // Row:11 Col:1
                    _tileXml.GetElementsByTagName("text")[21].InnerText = _Message[21];     // Row:11 Col:2
#endif
                    break;
                case TileTemplateType.TileSquare310x310Text09:
#if WINDOWS_APP
                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Title;
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _SubTitle[0];
                    _tileXml.GetElementsByTagName("text")[2].InnerText = _SubTitle[1];
                    _tileXml.GetElementsByTagName("text")[3].InnerText = _Message[0];
                    _tileXml.GetElementsByTagName("text")[4].InnerText = _Message[1];
                    _tileXml.GetElementsByTagName("text")[5].InnerText = _Message[2];
                    _tileXml.GetElementsByTagName("text")[6].InnerText = _Message[3];
                    _tileXml.GetElementsByTagName("text")[7].InnerText = _Message[4];
                    _tileXml.GetElementsByTagName("text")[8].InnerText = _Message[5];
                    _tileXml.GetElementsByTagName("text")[9].InnerText = _Message[6];
                    _tileXml.GetElementsByTagName("text")[10].InnerText = _Message[7];
                    _tileXml.GetElementsByTagName("text")[11].InnerText = _Message[8];
                    _tileXml.GetElementsByTagName("text")[12].InnerText = _Message[9];
                    _tileXml.GetElementsByTagName("text")[13].InnerText = _Message[10];
                    _tileXml.GetElementsByTagName("text")[14].InnerText = _Message[11];
                    _tileXml.GetElementsByTagName("text")[15].InnerText = _Message[12];
                    _tileXml.GetElementsByTagName("text")[16].InnerText = _Message[13];
                    _tileXml.GetElementsByTagName("text")[17].InnerText = _Message[14];
                    _tileXml.GetElementsByTagName("text")[18].InnerText = _Message[15];
#endif
                    break;
                case TileTemplateType.TileSquare310x310TextList01:
#if WINDOWS_APP
                    _tileXml.GetElementsByTagName("text")[0].InnerText = _SubTitle[0];
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[0];
                    _tileXml.GetElementsByTagName("text")[2].InnerText = _Message[1];

                    _tileXml.GetElementsByTagName("text")[3].InnerText = _SubTitle[1];
                    _tileXml.GetElementsByTagName("text")[4].InnerText = _Message[2];
                    _tileXml.GetElementsByTagName("text")[5].InnerText = _Message[3];

                    _tileXml.GetElementsByTagName("text")[6].InnerText = _SubTitle[2];
                    _tileXml.GetElementsByTagName("text")[7].InnerText = _Message[4];
                    _tileXml.GetElementsByTagName("text")[8].InnerText = _Message[5];
#endif
                    break;
                case TileTemplateType.TileSquare310x310TextList02:
#if WINDOWS_APP
                    _tileXml.GetElementsByTagName("text")[0].InnerText = _Message[0];
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[1];
                    _tileXml.GetElementsByTagName("text")[2].InnerText = _Message[2];
#endif
                    break;
                case TileTemplateType.TileSquare310x310TextList03:
#if WINDOWS_APP
                    _tileXml.GetElementsByTagName("text")[0].InnerText = _SubTitle[0];
                    _tileXml.GetElementsByTagName("text")[1].InnerText = _Message[0];

                    _tileXml.GetElementsByTagName("text")[2].InnerText = _SubTitle[1];
                    _tileXml.GetElementsByTagName("text")[3].InnerText = _Message[1];

                    _tileXml.GetElementsByTagName("text")[4].InnerText = _SubTitle[2];
                    _tileXml.GetElementsByTagName("text")[5].InnerText = _Message[2];
#endif
                    break;
                default:
#if WINDOWS_APP
#endif
#if WINDOWS_PHONE_APP
#endif
                    break;
            }
        }

#if WINDOWS_PHONE_APP
        public void Set_Xml3(ref Windows.Data.Xml.Dom.XmlDocument _tileXml)
        {   // For [Windows Phone]
            XmlNodeList xnl;

            switch (_TType)
            {
                case TileTemplateType.TileSquare71x71Image:
					xnl = _tileXml.GetElementsByTagName("image");
					((XmlElement)xnl[0]).SetAttribute("src", _Image[0]);
					((XmlElement)xnl[0]).SetAttribute("alt",@"alt text");
                    break;
                case TileTemplateType.TileSquare71x71IconWithBadge:
                    break;
                case TileTemplateType.TileSquare150x150IconWithBadge:
                    break;
                case TileTemplateType.TileWide310x150IconWithBadgeAndText:
                    break;

                case TileTemplateType.TileSquare99x99IconWithBadge:
                    break;
                case TileTemplateType.TileSquare210x210IconWithBadge:
                    break;
                case TileTemplateType.TileWide432x210IconWithBadgeAndText:
                    break;
                default:
//#if WINDOWS_APP
//#endif
//#if WINDOWS_PHONE_APP
//#endif
                    break;
            }
        }
#endif
        #endregion
    }
}
