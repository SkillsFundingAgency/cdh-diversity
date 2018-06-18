﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NCS.DSS.Diversity.ReferenceData;

namespace NCS.DSS.Diversity.GetDiversityHttpTrigger
{
    public class GetDiversityHttpTriggerService
    {
        public async Task<List<Models.Diversity>> GetDiversities()
        {
            var result = CreateTempDiversities();
            return await Task.FromResult(result);
        }

        public List<Models.Diversity> CreateTempDiversities()
        {
            var diversityList = new List<Models.Diversity>
            {
               new Models.Diversity
               {
                   DiversityId = Guid.Parse("b11676c9-e17f-4658-b35e-3fdc23b4adb3"),
                   CustomerId = Guid.NewGuid(),
                   ConsentToCollectLLDDHealth = true,
                   DateAndTimeLLDDHealthConsentCollected = DateTime.UtcNow,
                   LLDDHealthProblemDeclaration = LLDDHealthProblemDeclaration.CustomerConsidersThemselvesToHaveALearningDifficultyAndOrHealthProblem,
                   PrimaryLLDDHeathProblem = PrimaryLLDDHeathProblem.AspergersSyndrome,
                   ConsentToCollectEthnicity = false,
                   SecondaryLLDDHeathProblem = SecondaryLLDDHeathProblem.AutismSpectrumDisorder,
                   Ethnicity = Ethnicity.African,
                   LastModifiedDate = DateTime.UtcNow,
                   LastModifiedBy = Guid.Empty
               },
                new Models.Diversity
                {
                    DiversityId = Guid.Parse("2f9e4ece-95d9-444b-8833-b433f5fd2190"),
                    CustomerId = Guid.NewGuid(),
                    ConsentToCollectLLDDHealth = false,
                    LLDDHealthProblemDeclaration = LLDDHealthProblemDeclaration.CustomerDoesNotConsiderThemselvesToHaveALearningDifficultyAndOrHealthProblem,
                    PrimaryLLDDHeathProblem = PrimaryLLDDHeathProblem.AutismSpectrumDisorder,
                    ConsentToCollectEthnicity = true,
                    DateAndTimeEthnicityCollected = DateTime.UtcNow,
                    SecondaryLLDDHeathProblem = SecondaryLLDDHeathProblem.Dyscalculia,
                    Ethnicity = Ethnicity.Chinese,
                    LastModifiedDate = DateTime.UtcNow,
                    LastModifiedBy = Guid.Empty
                },
                new Models.Diversity
                {
                    DiversityId = Guid.Parse("67fefdd2-6e1c-48b8-b9be-2adc5d0d48c4"),
                    CustomerId = Guid.NewGuid(),
                    ConsentToCollectLLDDHealth = true,
                    DateAndTimeLLDDHealthConsentCollected = DateTime.UtcNow,
                    LLDDHealthProblemDeclaration = LLDDHealthProblemDeclaration.NotProvidedByTheCustomer,
                    PrimaryLLDDHeathProblem = PrimaryLLDDHeathProblem.NotProvided,
                    ConsentToCollectEthnicity = true,
                    DateAndTimeEthnicityCollected = DateTime.UtcNow,
                    SecondaryLLDDHeathProblem = SecondaryLLDDHeathProblem.TemporaryDisabilityAfterIllnessOrAccident,
                    Ethnicity = Ethnicity.GypsyIrishTraveller,
                    LastModifiedDate = DateTime.UtcNow,
                    LastModifiedBy = Guid.Empty
                }
            };

            return diversityList;
        }

    }
}
