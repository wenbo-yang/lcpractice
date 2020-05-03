using System;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1366_RankTeamByVotes
{
    [TestClass]
    public class RankTeamByVotesTests
    {
        [TestMethod]
        public void GivenListOfVotes_RankTeamByVotes_ShouldReturnCorrectAnswer()
        {
            var votes = new string[] { "WXYZ", "XYZW" };

            var result = RankTeamByVotes(votes);

            Assert.IsTrue(result == "XWYZ");
        }

        [TestMethod]
        public void GivenAnotherListOfVotes_RankTeamByVotes_ShouldReturnCorrectAnswer()
        {
            var votes = new string[] { "FVSHJIEMNGYPTQOURLWCZKAX", "AITFQORCEHPVJMXGKSLNZWUY", "OTERVXFZUMHNIYSCQAWGPKJL", "VMSERIJYLZNWCPQTOKFUHAXG", "VNHOZWKQCEFYPSGLAMXJIUTR", "ANPHQIJMXCWOSKTYGULFVERZ", "RFYUXJEWCKQOMGATHZVILNSP", "SCPYUMQJTVEXKRNLIOWGHAFZ", "VIKTSJCEYQGLOMPZWAHFXURN", "SVJICLXKHQZTFWNPYRGMEUAO", "JRCTHYKIGSXPOZLUQAVNEWFM", "NGMSWJITREHFZVQCUKXYAPOL", "WUXJOQKGNSYLHEZAFIPMRCVT", "PKYQIOLXFCRGHZNAMJVUTWES", "FERSGNMJVZXWAYLIKCPUQHTO", "HPLRIUQMTSGYJVAXWNOCZEKF", "JUVWPTEGCOFYSKXNRMHQALIZ", "MWPIAZCNSLEYRTHFKQXUOVGJ", "EZXLUNFVCMORSIWKTYHJAQPG", "HRQNLTKJFIEGMCSXAZPYOVUW", "LOHXVYGWRIJMCPSQENUAKTZF", "XKUTWPRGHOAQFLVYMJSNEIZC", "WTCRQMVKPHOSLGAXZUEFYNJI" };

            var result = RankTeamByVotes(votes);

            Assert.IsTrue(result == "VWFHSJARNPEMOXLTUKICZGYQ");
        }

        [TestMethod]
        public void GivenOneSetListOfVotes_RankTeamByVotes_ShouldReturnCorrectAnswer()
        {
            var votes = new string[] { "ZMNAGUEDSJYLBOPHRQICWFXTVK" };

            var result = RankTeamByVotes(votes);

            Assert.IsTrue(result == "ZMNAGUEDSJYLBOPHRQICWFXTVK");
        }

        private string RankTeamByVotes(string[] votes)
        {
            var bucket = GenerateVoteBucket();

            for (int i = 0; i < votes.Length; i++)
            {
                for (int j = 0; j < votes[i].Length; j++)
                {
                    bucket[votes[i][j] - 'A'].vote[j]++;
                }
            }

            var orderedEnumerable = bucket.OrderByDescending(x => x.vote[0])
                .ThenByDescending(x => x.vote[1])
                .ThenByDescending(x => x.vote[2])
                .ThenByDescending(x => x.vote[3])
                .ThenByDescending(x => x.vote[4])
                .ThenByDescending(x => x.vote[5])
                .ThenByDescending(x => x.vote[6])
                .ThenByDescending(x => x.vote[7])
                .ThenByDescending(x => x.vote[8])
                .ThenByDescending(x => x.vote[9])
                .ThenByDescending(x => x.vote[10])
                .ThenByDescending(x => x.vote[11])
                .ThenByDescending(x => x.vote[12])
                .ThenByDescending(x => x.vote[13])
                .ThenByDescending(x => x.vote[14])
                .ThenByDescending(x => x.vote[15])
                .ThenByDescending(x => x.vote[16])
                .ThenByDescending(x => x.vote[17])
                .ThenByDescending(x => x.vote[18])
                .ThenByDescending(x => x.vote[19])
                .ThenByDescending(x => x.vote[20])
                .ThenByDescending(x => x.vote[21])
                .ThenByDescending(x => x.vote[22])
                .ThenByDescending(x => x.vote[23])
                .ThenByDescending(x => x.vote[24])
                .ThenByDescending(x => x.vote[25]);

            var sb = new StringBuilder();
            var orderedArray = orderedEnumerable.ToArray();
            for (int i = 0; i < bucket.Length; i++)
            {
                if (orderedArray[i].vote.Sum() == 0)
                {
                    break;
                }
                sb.Append(orderedArray[i].team);
            }

            return sb.ToString();
        }

        private (int[] vote, char team)[] GenerateVoteBucket()
        {
            var result = new (int[] vote, char team)[26];

            for (int i = 0; i < result.Length; i++)
            {
                result[i].vote = new int[26]; result[i].team = (char)('A' + i);
            }

            return result;
        }
    }
}
