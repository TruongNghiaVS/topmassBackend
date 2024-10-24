namespace Topmass.Admin.Pages

{
    public class ImageControlItem : ControlItem
    {

        public ImageControlItem()
        {
            Type = 4;
        }

    }


    public class AvatarControlItem : ImageControlItem
    {

        public AvatarControlItem()
        {
            Type = 5;
        }
    }

    public class ControlItem
    {

        public string Name { get; set; }
        public string Value { get; set; }

        public int Type { get; set; }

        public string Lable { get; set; }



        public string PathControl
        {
            get
            {
                if (Type == 1)
                {
                    return "Control/textbox";
                }

                if (Type == 2)
                {
                    return "Control/editorText";
                }

                if (Type == 3)
                {
                    return "Control/selectBox";
                }
                if (Type == 5)
                {
                    return "Control/avatarUpload";
                }

                if (Type == 4)
                {
                    return "Control/FileInputCs";
                }

                if (Type == 7)
                {
                    return "Control/selectBox2";
                }
                return "Control/textbox";
            }
        }

        public ControlItem()
        {
            Type = 1;
        }
    }
}