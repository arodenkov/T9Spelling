using T9SpellingApp.Transformers;

namespace T9SpellingTests
{
    public class StringToNumKeyboardTests
    {
        StringToNumKeyboardTransformer str2numTransformer = new();
        
        [SetUp]
        public void Setup()
        {
        }

        [Test(Description = "Use string transformation with null value string.")]
        public void NullStringTest()
        {
            try
            {
                Assert.Pass(str2numTransformer.Transform(s: null!));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }

        [Test(Description = "Use string transformation with empty value string.")]
        public void EmptyStringTest()
        {
            try
            {
                Assert.Pass(str2numTransformer.Transform(string.Empty));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }

        [Test(Description = "Use string transformation with cyrillic string.")]
        public void NonLatinLettersTest01()
        {
            try
            {
                Assert.Pass(str2numTransformer.Transform("ûâàûõçæ"));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }

        [Test(Description = "Use string transformation with string of numbers and cyrillic string.")]
        public void NonLatinLettersTest02()
        {
            try
            {
                Assert.Pass(str2numTransformer.Transform("123141âûÀÛûâÿ÷"));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }

        [Test(Description = "Use string transformation with latin-letters string with a few upper case letters.")]
        public void CapitalCaseTest()
        {
            try
            {
                Assert.Pass(str2numTransformer.Transform("aBcDe"));
            }
            catch(Exception ex)
            {
                Assert.Fail(ex.ToString());
            }           
        }
    }
}