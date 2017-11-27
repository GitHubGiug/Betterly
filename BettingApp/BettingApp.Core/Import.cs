using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BettingApp.BettingApp.Core
{
    class Import
    {
        internal static List<Bet> ReadCSV(List<Bet> stats)
        {

            ConnectionStringSettings csv = ConfigurationManager.ConnectionStrings["csv"];

            using (OleDbConnection cn = new OleDbConnection(csv.ConnectionString))
            {
                cn.Open();
                using (OleDbCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM [Bet_Data.csv]";
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        int betId = reader.GetOrdinal("betId");
                        int betTimestamp = reader.GetOrdinal("betTimestamp");
                        int selectionId = reader.GetOrdinal("selectionId");
                        int selectionName = reader.GetOrdinal("selectionName");
                        int stake = reader.GetOrdinal("stake");
                        int price = reader.GetOrdinal("price");
                        int currency = reader.GetOrdinal("currency");

                        foreach (DbDataRecord record in reader)
                        {
                            stats.Add(new Bet
                            {
                                BetId = record.GetString(betId),
                                BetTimestamp = (long)record.GetDouble(betTimestamp),
                                SelectionId = record.GetInt32(selectionId),
                                SelectionName = record.GetString(selectionName),
                                Stake = record.GetDouble(stake),
                                Price = record.GetDouble(price),
                                Currency = record.GetString(currency)

                            });
                        }
                    }
                }
            }
            return stats;
        }

        internal static List<Bet> ReadXML(List<Bet> stats, string filePath)
        {

            XmlSerializer serializer = new XmlSerializer(typeof(List<Bet>));
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
            {
                var result = (List<Bet>)serializer.Deserialize(fileStream);
                return result;
            }
        }
    }
}
