namespace Topmass.Business.Regional
{
    public class GlobalRegional
    {

        public static GlobalRegional _globalRegional = null;

        public GlobalRegional()
        {

        }
        public GlobalRegional GetRegional()
        {
            if (_globalRegional == null)
            {
                _globalRegional = new GlobalRegional();
            }
            return _globalRegional;
        }

    }
}
