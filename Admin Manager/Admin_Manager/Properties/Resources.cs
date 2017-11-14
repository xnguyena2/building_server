namespace Admin_Manager.Properties
{
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Globalization;
    using System.Resources;
    using System.Runtime.CompilerServices;

    [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0"), DebuggerNonUserCode, CompilerGenerated]
    internal class Resources
    {
        private static CultureInfo resourceCulture;
        private static System.Resources.ResourceManager resourceMan;

        internal Resources()
        {
        }

        internal static Bitmap addblock =>
            ((Bitmap) ResourceManager.GetObject("addblock", resourceCulture));

        internal static Bitmap addblock8 =>
            ((Bitmap) ResourceManager.GetObject("addblock8", resourceCulture));

        internal static Bitmap admin_bar =>
            ((Bitmap) ResourceManager.GetObject("admin bar", resourceCulture));

        internal static Bitmap admin_lever =>
            ((Bitmap) ResourceManager.GetObject("admin lever", resourceCulture));

        internal static Bitmap caroulsel =>
            ((Bitmap) ResourceManager.GetObject("caroulsel", resourceCulture));

        internal static Bitmap changepassword =>
            ((Bitmap) ResourceManager.GetObject("changepassword", resourceCulture));

        internal static Bitmap choose_file =>
            ((Bitmap) ResourceManager.GetObject("choose-file", resourceCulture));

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static CultureInfo Culture
        {
            get
            {
                return resourceCulture;
            }
            set
            {
                resourceCulture = value;
            }
        }

        internal static Bitmap gray_login_extra_thin_button_hi =>
            ((Bitmap) ResourceManager.GetObject("gray-login-extra-thin-button-hi", resourceCulture));

        internal static Bitmap gray_login_extra_thin_button_hi1 =>
            ((Bitmap) ResourceManager.GetObject("gray-login-extra-thin-button-hi1", resourceCulture));

        internal static Bitmap padding =>
            ((Bitmap) ResourceManager.GetObject("padding", resourceCulture));

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    System.Resources.ResourceManager manager = new System.Resources.ResourceManager("Admin_Manager.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = manager;
                }
                return resourceMan;
            }
        }
    }
}

