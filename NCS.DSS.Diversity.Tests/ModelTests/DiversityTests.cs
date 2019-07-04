﻿using System;
using NCS.DSS.Diversity.ReferenceData;
using NSubstitute;
using NUnit.Framework;

namespace NCS.DSS.Diversity.Tests.ModelTests
{
    [TestFixture]
    public class DiversityTests
    {

        [Test]
        public void DiversityTests_PopulatesDefaultValues_WhenSetDefaultValuesIsCalled()
        {
            var diversity = new Models.Diversity();
            diversity.SetDefaultValues();

            // Assert
            Assert.IsNotNull(diversity.LastModifiedDate);
            Assert.AreEqual(PrimaryLearningDifficultyOrDisability.NotProvided, diversity.PrimaryLearningDifficultyOrDisability);
            Assert.AreEqual(SecondaryLearningDifficultyOrDisability.NotProvided, diversity.SecondaryLearningDifficultyOrDisability);
        }

        [Test]
        public void DiversityTests_CheckLastModifiedDateDoesNotGetPopulated_WhenSetDefaultValuesIsCalled()
        {
            var diversity = new Models.Diversity { LastModifiedDate = DateTime.MaxValue };

            diversity.SetDefaultValues();

            // Assert
            Assert.AreEqual(DateTime.MaxValue, diversity.LastModifiedDate);
        }
        
        [Test]
        public void DiversityTests_CheckPrimaryLearningDifficultyOrDisabilityDoesNotGetPopulated_WhenSetDefaultValuesIsCalled()
        {
            var diversity = new Models.Diversity { PrimaryLearningDifficultyOrDisability = PrimaryLearningDifficultyOrDisability.Dyslexia };

            diversity.SetDefaultValues();

            // Assert
            Assert.AreEqual(PrimaryLearningDifficultyOrDisability.Dyslexia, diversity.PrimaryLearningDifficultyOrDisability);
        }

        [Test]
        public void DiversityTests_CheckSecondaryLearningDifficultyOrDisabilityDoesNotGetPopulated_WhenSetDefaultValuesIsCalled()
        {
            var diversity = new Models.Diversity { SecondaryLearningDifficultyOrDisability = SecondaryLearningDifficultyOrDisability.Dyslexia };

            diversity.SetDefaultValues();

            // Assert
            Assert.AreEqual(SecondaryLearningDifficultyOrDisability.Dyslexia, diversity.SecondaryLearningDifficultyOrDisability);
        }
        [Test]
        public void DiversityTests_CheckDiversityIdIsSet_WhenSetIdsIsCalled()
        {
            var diversity = new Models.Diversity();

            diversity.SetIds(Arg.Any<Guid>(), Arg.Any<string>());

            // Assert
            Assert.AreNotSame(Guid.Empty, diversity.DiversityId);
        }

        [Test]
        public void DiversityTests_CheckCustomerIdIsSet_WhenSetIdsIsCalled()
        {
            var diversity = new Models.Diversity();

            var customerId = Guid.NewGuid();
            diversity.SetIds(customerId, Arg.Any<string>());

            // Assert
            Assert.AreEqual(customerId, diversity.CustomerId);
        }

       [Test]
        public void DiversityTests_CheckLastModifiedTouchpointIdIsSet_WhenSetIdsIsCalled()
        {
            var diversity = new Models.Diversity();

            diversity.SetIds(Arg.Any<Guid>(), "0000000000");

            // Assert
            Assert.AreEqual("0000000000", diversity.LastModifiedBy);
        }
        
    }
}