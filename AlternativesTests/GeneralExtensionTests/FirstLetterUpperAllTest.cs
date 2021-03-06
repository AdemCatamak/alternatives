﻿using Alternatives;
using Xunit;

namespace AlternativesTest.GeneralExtensionTests
{
    public class FirstLetterUpperAllTest
    {
        [Fact]
        public void FirstLetterUpperAll_WhenNullAsObject_ResponseMustBeEmptyString()
        {
            string expected = string.Empty;


            string actual = ((string) null).FirstLetterToUpperAll();


            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FirstLetterUpperAll_WhenEmptyStringAsObj_ResponseMustBeEmptyString()
        {
            string expected = string.Empty;


            string actual = string.Empty.FirstLetterToUpperAll();


            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FirstLetterUpperAll_WhenFirstLetterIsDigit_CharacterMustNotEffected()
        {
            const string expected = "2131";
            const string data = "2131";

            string actual = data.FirstLetterToUpperAll();


            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FirstLetterUpperAll_WhenFirstCharacterIsLetter_CharacterMustBeCapitalized()
        {
            const string expected = "Adem",
                         data = "adem";

            string actual = data.FirstLetterToUpperAll();


            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FirstLetterUpperAll_WhenHasSpaceAtTheEnd_ResponseHasCapitalizedFirstLetterAndRemovedSpaceAtTheEnd()
        {
            const string expected = "Adem",
                         data = "adem ";

            string actual = data.FirstLetterToUpperAll();


            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FirstLetterUpperAll_WhenStringHasSpaceBetweenCharacter_EachWordHasCapitalizedFirstLetter()
        {
            const string expected = "Adem Catamak",
                         data = "adem catamak ";

            string actual = data.FirstLetterToUpperAll();


            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FirstLetterUpperAll_WhenStringHasGivenSplitter_EachLetterHasCapitalized()
        {
            const string expected = "All first letter is change upper version of all sentences after FirstLetterToUpperAll function run. Try it if you do not believe",
                         data = "all first letter is change upper version of all sentences after FirstLetterToUpperAll function run. try it if you do not believe";

            string actual = data.FirstLetterToUpperAll('.');


            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FirstLetterUpperAll_WhenGivenSplitterOneAfterAnother_ResponseMustBeSuccessfully()
        {
            const string expected = "Adem, Catamak",
                         data = "adem, catamak";

            string actual = data.FirstLetterToUpperAll(',', ' ');


            Assert.Equal(expected, actual);
        }
    }
}