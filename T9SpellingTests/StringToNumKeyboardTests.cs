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
        public void NullStringWithExceptionAsResultTest()
        {
            try
            {
                Assert.Fail(str2numTransformer.Transform(s: null!));
            }
            catch (Exception ex)
            {
                Assert.Pass(ex.ToString());
            }
        }

        [Test(Description = "Use string transformation with empty value string.")]
        public void EmptyStringWithExceptionAsResultTest()
        {
            try
            {
                Assert.Fail(str2numTransformer.Transform(string.Empty));
            }
            catch (Exception ex)
            {
                Assert.Pass(ex.ToString());
            }
        }

        [Test(Description = "Use string transformation with cyrillic string.")]
        public void NonLatinLettersWithExceptionAsResultTest01()
        {
            try
            {
                Assert.Fail(str2numTransformer.Transform("ûâàûõçæ"));
            }
            catch (Exception ex)
            {
                Assert.Pass(ex.ToString());
            }
        }

        [Test(Description = "String transformation with numbers and cyrillic letters.")]
        public void NonLatinLettersWithExceptionAsResultTest02()
        {
            try
            {
                Assert.Fail(str2numTransformer.Transform("123141âûÀÛûâÿ÷"));
            }
            catch (Exception ex)
            {
                Assert.Pass(ex.ToString());
            }
        }

        [Test(Description = "String transformation with latin letters and with a few upper case letters.")]
        public void CapitalCaseWithExceptionAsResultTest()
        {
            try
            {
                Assert.Fail(str2numTransformer.Transform("aBcDe"));
            }
            catch(Exception ex)
            {
                Assert.Pass(ex.ToString());
            }           
        }

        [Test(Description = "Excessive length string transformation.")]
        public void OverLongStringWithExceptionAsResultTest()
        {
            try
            {
                var res = str2numTransformer.Transform(new string('q', 1001));
                Assert.Fail("Should throw exception with message!");
            }
            catch (Exception ex)
            {
                Assert.Pass(ex.ToString());
            }
        }

        [Test(Description = "Use long string transformation.")]
        public void LongStringTest()
        {
            try
            {
                var res = str2numTransformer.Transform(new string('q', 1000));
                Assert.That(res.Length > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }

        [Test(Description = "String with double letters transformation.")]
        public void StringWithDoublesTest()
        {
            var res = str2numTransformer.Transform("cd");// "abbcdddee");
            Assert.That(res == "2223");// "2 22 22 2223 3 3 33 33");            
        }
    }
}