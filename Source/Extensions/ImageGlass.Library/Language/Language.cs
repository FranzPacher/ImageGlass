﻿/*
ImageGlass Project - Image viewer for Windows
Copyright (C) 2014 DUONG DIEU PHAP
Project homepage: http://imageglass.org

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System.Collections.Generic;
using System.Xml;

namespace ImageGlass.Library
{
    public class Language
    {
        private string _langCode;
        private string _langName;
        private string _author;
        private string _description;
        private string _fileName;
        private Dictionary<string, string> _Items;

        #region Properties
        /// <summary>
        /// Get, set code of language
        /// </summary>
        public string LangCode
        {
            get { return _langCode; }
            set { _langCode = value; }
        }

        //Get, set name of language
        public string LangName
        {
            get { return _langName; }
            set { _langName = value; }
        }

        //Get, set author
        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }

        /// <summary>
        /// Get, set description
        /// </summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        /// <summary>
        /// Get, set language file path
        /// </summary>
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        /// <summary>
        /// Get, set list of language string
        /// </summary>
        public Dictionary<string, string> Items
        {
            get { return _Items; }
            set { _Items = value; }
        }
        #endregion


        /// <summary>
        /// Set default values of Language
        /// </summary>
        public Language()
        {
            _langCode = "en";
            _langName = "English";
            _author = "Dương Diệu Pháp";
            _description = "English";
            _fileName = "";

            _Items = new Dictionary<string, string>();
            InitDefaultLanguageDictionary();
        }


        /// <summary>
        /// Set values of Language
        /// </summary>
        /// <param name="fileName">*.igLang path</param>
        public Language(string fileName)
        {
            _Items = new Dictionary<string, string>();
            InitDefaultLanguageDictionary();

            _fileName = fileName;
            ReadLanguageFile();
        }


        /// <summary>
        /// Read language strings from file (new format)
        /// </summary>
        public void ReadLanguageFile()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(_fileName);
            XmlElement root = (XmlElement)doc.DocumentElement;// <ImageGlass>
            XmlElement nType = (XmlElement)root.SelectNodes("Language")[0]; //<Language>
            XmlElement n = (XmlElement)nType.SelectNodes("Info")[0];//<Info>

            //Get <Info> Attributes
            this.LangCode = n.GetAttribute("langCode");
            this.LangName = n.GetAttribute("langName");
            this.Author = n.GetAttribute("author");
            this.Description = n.GetAttribute("description");

            //Get <Content> element
            XmlElement nContent = (XmlElement)nType.SelectNodes("Content")[0];//<Content>

            //Get all lang items
            XmlNodeList nLangList = nContent.SelectNodes("Item");//<Item>

            foreach (var item in nLangList)
            {
                XmlElement nItem = (XmlElement)item;
                string _key = nItem.GetAttribute("key");
                string _value = nItem.GetAttribute("value").Replace("\\n", "\n");

                try
                {
                    this.Items[_key] = _value;
                }
                catch { }
            }
        }


        /// <summary>
        /// This is default language of ImageGlass
        /// </summary>
        private void InitDefaultLanguageDictionary()
        {
            //frmMain
            this.Items.Add("frmMain.picMain._ErrorText", "ImageGlass cannot open this picture because the file appears to be damaged, or corrupted.");//v2.0 beta
            this.Items.Add("frmMain.btnBack", "Go to previous image (Left arrow / PageDown)");
            this.Items.Add("frmMain.btnNext", "Go to next image (Right arrow / PageUp)");
            this.Items.Add("frmMain.btnRotateLeft", "Rotate Counterclockwise (Ctrl + ,)");
            this.Items.Add("frmMain.btnRotateRight", "Rotate Clockwise (Ctrl + .)");
            this.Items.Add("frmMain.btnZoomIn", "Zoom in (Ctrl + =)");
            this.Items.Add("frmMain.btnZoomOut", "Zoom out (Ctrl + -)");
            this.Items.Add("frmMain.btnActualSize", "Actual size (Ctrl + 0)");
            this.Items.Add("frmMain.btnZoomLock", "Lock zoom ratio (Ctrl + L)");
            this.Items.Add("frmMain.btnScaletoWidth", "Scale to Width (Ctrl + W)");
            this.Items.Add("frmMain.btnScaletoHeight", "Scale to Height (Ctrl + H)");
            this.Items.Add("frmMain.btnWindowAutosize", "Window adapt to image (Ctrl + M)");
            this.Items.Add("frmMain.btnOpen", "Open file (Ctrl + O)");
            this.Items.Add("frmMain.btnRefresh", "Refresh (F5)");
            this.Items.Add("frmMain.btnGoto", "Go to ... (Ctrl + G)");
            this.Items.Add("frmMain.btnThumb", "Show thumbnail (Ctrl + T)");
            this.Items.Add("frmMain.btnCaro", "Show checked background (Ctrl + B)");
            this.Items.Add("frmMain.btnFullScreen", "Full sreen (Alt + Enter)");
            this.Items.Add("frmMain.btnSlideShow", "Play slideshow (F11, ESC to exit)");
            this.Items.Add("frmMain.btnConvert", "Convert image (Ctrl + S)");
            this.Items.Add("frmMain.btnPrintImage", "Print image (Ctrl + P)");
            this.Items.Add("frmMain.btnFacebook", "Upload to Facebook (Ctrl + U)");
            this.Items.Add("frmMain.btnExtension", "Extension Manager (Ctrl + Shift + E)");
            this.Items.Add("frmMain.btnSetting", "ImageGlass Settings (Ctrl + Shift + P)");
            this.Items.Add("frmMain.btnHelp", "Help (F1)");
            //this.Items.Add("frmMain.btnFacebookLike", "Find ImageGlass on the Internet"); //removed v2.0 final
            //this.Items.Add("frmMain.btnFollow", "Follow ImageGlass by email"); //removed v2.0 final
            this.Items.Add("frmMain.btnReport", "Leave ImageGlass feedbacks");
            this.Items.Add("frmMain.mnuStartSlideshow", "Start slideshow");
            this.Items.Add("frmMain.mnuStopSlideshow", "Stop slideshow");
            this.Items.Add("frmMain.mnuExitSlideshow", "Exit slideshow");
            this.Items.Add("frmMain.mnuShowToolBar._Hide", "Hide toolbar");
            this.Items.Add("frmMain.mnuShowToolBar._Show", "Show toolbar");
            this.Items.Add("frmMain.mnuEditWithPaint", "Edit with Paint");
            this.Items.Add("frmMain.mnuExtractFrames", "Extract image frames ({0})");
            this.Items.Add("frmMain.mnuSetWallpaper", "Set as desktop background");

            this.Items.Add("frmMain.mnuPasteImage", "Paste image data"); //v2.0 final
            this.Items.Add("frmMain.mnuCopy", "Copy"); //v2.0 final
            this.Items.Add("frmMain.mnuMultiCopy", "Copy multiple files"); //v2.0 final
            this.Items.Add("frmMain.mnuCut", "Cut"); //v2.0 final
            this.Items.Add("frmMain.mnuMultiCut", "Cut multiple files"); //v2.0 final
            this.Items.Add("frmMain.mnuClearClipboard", "Clear clipboard"); //v2.0 final

            this.Items.Add("frmMain.mnuMoveRecycle", "Move to recycle bin");
            this.Items.Add("frmMain.mnuDelete", "Delete from hard disk");
            this.Items.Add("frmMain.mnuRename", "Rename image");
            this.Items.Add("frmMain.mnuUploadFacebook", "Upload to Facebook");
            this.Items.Add("frmMain.mnuCopyImagePath", "Copy image path");
            this.Items.Add("frmMain.mnuOpenLocation", "Open image location");
            this.Items.Add("frmMain.mnuImageProperties", "Image properties");
            this.Items.Add("frmMain._OpenFileDialog", "All supported files");
            this.Items.Add("frmMain._Text", "file(s)");
            this.Items.Add("frmMain._RenameDialog", "Enter new filename");
            this.Items.Add("frmMain._GotoDialogText", "Enter the image index to view it. Press {ENTER}");
            this.Items.Add("frmMain._DeleteDialogText", "Delete file '{0}' ?");
            this.Items.Add("frmMain._DeleteDialogTitle", "Confirm");
            this.Items.Add("frmMain._RecycleBinDialogText", "Send file '{0}' to recycle bin ?");
            this.Items.Add("frmMain._RecycleBinDialogTitle", "Confirm");
            this.Items.Add("frmMain._ExtractFrameText", "Select output folder");
            this.Items.Add("frmMain._FullScreenMessage", "Press ALT + ENTER to exit full screen mode.\nOr CTRL + F1 to show menu.");//v2.0 beta
            this.Items.Add("frmMain._SlideshowMessage", "Press ESC to exit slideshow.\n Right click to open context menu.");//v2.0 beta
            this.Items.Add("frmMain._CopyFileText", "Copied {0} file(s)."); //v2.0 final
            this.Items.Add("frmMain._CutFileText", "Cut {0} file(s)."); //v2.0 final
            this.Items.Add("frmMain._ClearClipboard", "Clipboard was cleared."); //v2.0 final
            this.Items.Add("frmMain._SaveChanges", "Saving change..."); //v2.0 final
            this.Items.Add("frmExtension._Text", "Extension Manager");
            //this.Items.Add("frmExtension.lnkGetMoreExt", "Get more extensions"); //removed v2.0 final
            this.Items.Add("frmExtension.btnGetMoreExt", "Get more extensions"); //v2.0 final
            this.Items.Add("frmExtension.btnRefreshAllExt", "Refresh"); //v2.0 final
            this.Items.Add("frmExtension.btnInstallExt", "Install"); //v2.0 final
            //this.Items.Add("frmExtension.Node0", "Get more extensions"); //removed v2.0 final
            this.Items.Add("frmExtension.btnClose", "Close");
            this.Items.Add("frmFacebook.lblMessage", "Message:");
            this.Items.Add("frmFacebook.btnUpload._Upload", "Upload");
            this.Items.Add("frmFacebook.btnUpload._Cancel", "Cancel");
            this.Items.Add("frmFacebook.btnUpload._ViewImage", "View image");
            this.Items.Add("frmFacebook.btnClose", "Close");
            this.Items.Add("frmFacebook._StatusBegin", "click '{0}' to begin");
            this.Items.Add("frmFacebook._StatusInvalid", "invalid filename");
            this.Items.Add("frmFacebook._StatusUploading", "uploading...");
            this.Items.Add("frmFacebook._StatusCancel", "cancelled");
            this.Items.Add("frmFacebook._StatusSuccessful", "successful");
            this.Items.Add("frmFaceBookLogin._Text", "Logging in to Facebook ...");
            this.Items.Add("frmAbout.lblSlogant", "Free and open source image viewer");
            this.Items.Add("frmAbout.lblInfo", "Information");
            this.Items.Add("frmAbout.lblComponent", "Components");
            this.Items.Add("frmAbout.lblReferences", "References");
            this.Items.Add("frmAbout.lblVersion", "Version: {0}");
            this.Items.Add("frmAbout.lblInfoContact", "Contact:");
            this.Items.Add("frmAbout.lblSoftwareUpdate", "Software updates:");
            this.Items.Add("frmAbout.lnkCheckUpdate", "» Check for update");
            this.Items.Add("frmAbout._Text", "About");
            this.Items.Add("frmSetting._Text", "Settings");
            this.Items.Add("frmSetting.lblGeneral", "General");
            //this.Items.Add("frmSetting.lblContextMenu", "Context menu"); //removed v2.0 final
            this.Items.Add("frmSetting.lblFileAssociations", "File Associations"); //v2.0 final
            this.Items.Add("frmSetting.lblLanguage", "Language");
            //this.Items.Add("frmSetting.chkLockWorkspace", "Lock to workspace edge"); //removed v2.0 beta
            this.Items.Add("frmSetting.chkAutoUpdate", "Check for update automatically");
            this.Items.Add("frmSetting.chkFindChildFolder", "Find images in child folder");
            this.Items.Add("frmSetting.chkWelcomePicture", "Show welcome picture");
            this.Items.Add("frmSetting.chkHideToolBar", "Hide toolbar when start up");
            this.Items.Add("frmSetting.chkLoopSlideshow", "Loop back slideshow to the first image when reaching the end of the list"); //v2.0 final
            this.Items.Add("frmSetting.chkImageBoosterBack", "Turn on Image Booster when navigate back (need more ~20% RAM)"); //v2.0 final
            this.Items.Add("frmSetting.chkESCToQuit", "Allow to press ESC to quit application"); //v2.0 final
            this.Items.Add("frmSetting.lblGeneral_ZoomOptimization", "Zoom optimization:");
            this.Items.Add("frmSetting.cmbZoomOptimization._Auto", "Auto");
            this.Items.Add("frmSetting.cmbZoomOptimization._SmoothPixels", "Smooth pixels");
            this.Items.Add("frmSetting.cmbZoomOptimization._ClearPixels", "Clear pixels");
            this.Items.Add("frmSetting.lblSlideshowInterval", "Slide show interval: {0}");
            this.Items.Add("frmSetting.lblGeneral_MaxFileSize", "Maximum thumbnail file size (MB):");
            this.Items.Add("frmSetting.lblImageLoadingOrder", "Image loading order:");
            this.Items.Add("frmSetting.cmbImageOrder._Name", "Name (default)");
            this.Items.Add("frmSetting.cmbImageOrder._Length", "Length");
            this.Items.Add("frmSetting.cmbImageOrder._CreationTime", "Creation time");
            this.Items.Add("frmSetting.cmbImageOrder._LastAccessTime", "Last access time");
            this.Items.Add("frmSetting.cmbImageOrder._LastWriteTime", "Last write time");
            this.Items.Add("frmSetting.cmbImageOrder._Extension", "Extension");
            this.Items.Add("frmSetting.cmbImageOrder._Random", "Random");
            this.Items.Add("frmSetting.lblBackGroundColor", "Background color:");
            this.Items.Add("frmSetting.btnClose", "Close");
            this.Items.Add("frmSetting._OpenWithImageGlass", "Open with ImageGlass");
            //this.Items.Add("frmSetting.lbl_ContextMenu_Description", "This feature helps you open an image quickly by context menu. 'Add default' button lets you add the context menu into all supported extensions of ImageGlass. If you want to customize your extensions, please modify them in 'Extensions' textbox, and then click 'Update' button. 'Remove all' button lets you remove all context menus related to ImageGlass.\n\nAdd shortcut 'Open with ImageGlass' to context menu."); //removed 2.0 final
            this.Items.Add("frmSetting.lblExtensions", "Extensions:");
            this.Items.Add("frmSetting.btnAddDefaultExtension", "Add default"); //add 2.0 final
            //this.Items.Add("frmSetting.lblAddDefaultContextMenu", "Add default"); //removed 2.0 final
            this.Items.Add("frmSetting.lblContextMenu", "Context menu:"); //add 2.0 final
            this.Items.Add("frmSetting.btnUpdateContextMenu", "Update"); //add 2.0 final
            this.Items.Add("frmSetting.btnRemoveAllContextMenu", "Remove all"); //add 2.0 final
            //this.Items.Add("frmSetting.lblUpdateContextMenu", "Update"); //removed 2.0 final
            //this.Items.Add("frmSetting.lblRemoveAllContextMenu", "Remove all"); //removed 2.0 final
            this.Items.Add("frmSetting.lblFileAssociationsMng", "File associations:"); //add 2.0 final
            this.Items.Add("frmSetting.btnSetAssociations", "Set associations"); //add 2.0 final
            this.Items.Add("frmSetting.btnOpenFileAssociations", "Open File Associations"); //add 2.0 final

            this.Items.Add("frmSetting.lblLanguageText", "Installed languages:");
            this.Items.Add("frmSetting.lnkRefresh", "> Refresh");
            this.Items.Add("frmSetting.lnkInstallLanguage", "> Install new language pack (*.iglang)"); //v2.0 final
            this.Items.Add("frmSetting.lnkCreateNew", "> Create new language pack");
            this.Items.Add("frmSetting.lnkEdit", "> Edit selected language pack");
            this.Items.Add("frmSetting.lnkGetMoreLanguage", "> Get more language packs");
            
        }



    }
}
