using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Mazak
{
    public static class Parse
    {
        public static void Execute(byte[] Data)
        {
            //Parse Machine IP
            ParseIp(Data);
            //Parse MCName
            ParseMachineName(Data);
            //Parse Machine Status
            ParseStatus(Data);
            //Parse Machine Mode
            ParseMode(Data);
            //Parse Machine Feedrate
            ParseFeedRate(Data);
            //Parse Machine Rapid
            ParseRapidRate(Data);
            //Parse Machine SpFeedrate
            ParseFeedSPRate(Data);
            //Parse Machine ProgramNumber
            ParseProgramNumber(Data);
            //Parse Machine ProgramName
            ParseProgramName(Data);
            //Parse Machine SubProgramNumber
            ParseSubProgramNumber(Data);
            //Parse Machine ProgramName
            ParseSubProgramName(Data);
            //Parse Alarm Color
            ParseAlarmColor(Data);
            //Parse Alarm Message
            ParseAlarmMessage(Data);
            //Parse Alarm Number
            ParseAlarmNumber(Data);
            //Parse Machine PartCount
            ParsePartCount(Data);
            //Parse Machine Tool
            ParseTool(Data);
        }

        public static void ParseIp(byte[] UDPData)
        {
            byte[] MIp = new byte[22];
            MIp[0] = UDPData[32];
            MIp[1] = UDPData[33];
            MIp[2] = UDPData[34];
            MIp[3] = UDPData[35];
            MIp[4] = UDPData[36];
            MIp[5] = UDPData[37];
            MIp[6] = UDPData[38];
            MIp[7] = UDPData[39];
            MIp[8] = UDPData[40];
            MIp[9] = UDPData[41];
            MIp[10] = UDPData[42];
            MIp[11] = UDPData[43];
            MIp[12] = UDPData[44];
            MIp[13] = UDPData[45];
            MIp[14] = UDPData[46];
            MIp[15] = UDPData[47];
            MIp[16] = UDPData[48];
            MIp[17] = UDPData[49];
            MIp[18] = UDPData[50];
            MIp[19] = UDPData[51];
            MIp[20] = UDPData[52];
            MIp[21] = UDPData[53];
            string machineIP = (String)Encoding.ASCII.GetString(MIp).Trim('\0');
        }

        public static void ParseMachineName(byte[] UDPData)
        {
            //Make MCName Byte Array
            byte[] MCName = new byte[30];
            MCName[0] = UDPData[3];
            MCName[1] = UDPData[4];
            MCName[2] = UDPData[5];
            MCName[3] = UDPData[6];
            MCName[4] = UDPData[7];
            MCName[5] = UDPData[8];
            MCName[6] = UDPData[9];
            MCName[7] = UDPData[10];
            MCName[8] = UDPData[11];
            MCName[9] = UDPData[12];
            MCName[10] = UDPData[13];
            MCName[11] = UDPData[14];
            MCName[12] = UDPData[15];
            MCName[13] = UDPData[16];
            MCName[14] = UDPData[17];
            MCName[15] = UDPData[18];
            MCName[16] = UDPData[19];
            MCName[17] = UDPData[20];
            MCName[18] = UDPData[21];
            MCName[19] = UDPData[22];
            MCName[20] = UDPData[23];
            MCName[21] = UDPData[24];
            MCName[22] = UDPData[25];
            MCName[23] = UDPData[26];
            MCName[24] = UDPData[27];
            MCName[25] = UDPData[28];
            MCName[26] = UDPData[29];
            MCName[27] = UDPData[30];
            MCName[28] = UDPData[31];
            MCName[29] = UDPData[32];
            string machineName = (String)Encoding.ASCII.GetString(MCName).Trim('\0');
        }

        public static void ParseStatus(byte[] UDPData)
        {
            byte[] MCStatus = new byte[1];

            MCStatus[0] = UDPData[88];

            string status;

            switch ((String)Encoding.ASCII.GetString(MCStatus))
            {
                case "0":
                    status = "STOPPED";
                    break;
                case "1":
                    status = "ACTIVE";
                    break;
                case "2":
                    status = "FEED_HOLD";
                    break;
                case "3":
                    status = "STOPPED";
                    break;
                case "4":
                    status = "STOPPED";
                    break;
                case "5":
                    status = "ACTIVE";
                    break;
                case "6":
                    status = "STOPPED";
                    break;
            }
        }

        public static void ParseMode(byte[] UDPData)
        {
            string Mode = "";

            byte[] MCMode = new byte[1];
            MCMode[0] = UDPData[87];
            switch ((String)Encoding.ASCII.GetString(MCMode))
            {
                case "0":
                    Mode = "";
                    break;
                case "1":
                    Mode = "AUTOMATIC";
                    break;
                case "2":
                    Mode = "MANUAL_DATA_INPUT";
                    break;
                case "3":
                    Mode = "MANUAL_DATA_INPUT";
                    break;
                case "4":
                    Mode = "MANUAL";
                    break;
                case "5":
                    Mode = "EDIT";
                    break;
            }
        }

        public static void ParseFeedRate(byte[] UDPData)
        {
            byte[] MCFeed = new byte[3];
            MCFeed[0] = UDPData[357];
            MCFeed[1] = UDPData[358];
            MCFeed[2] = UDPData[359];

            string FeedRate = (String)Encoding.ASCII.GetString(MCFeed).Trim('\0');
        }

        public static void ParseRapidRate(byte[] UDPData)
        {
            byte[] MCFeed = new byte[3];
            MCFeed[0] = UDPData[349];
            MCFeed[1] = UDPData[350];
            MCFeed[2] = UDPData[351];

            string FeedRate = (String)Encoding.ASCII.GetString(MCFeed).Trim('\0');
        }

        public static void ParseFeedSPRate(byte[] UDPData)
        {
            byte[] MCFeedSP = new byte[3];
            MCFeedSP[0] = UDPData[353];
            MCFeedSP[1] = UDPData[354];
            MCFeedSP[2] = UDPData[355];

            string SpFeedRate = (String)Encoding.ASCII.GetString(MCFeedSP).Trim('\0');
        }

        public static void ParseProgramNumber(byte[] UDPData)
        {
            byte[] MCProgramNumber = new byte[8];
            MCProgramNumber[0] = UDPData[89];
            MCProgramNumber[1] = UDPData[90];
            MCProgramNumber[2] = UDPData[91];
            MCProgramNumber[3] = UDPData[92];
            MCProgramNumber[4] = UDPData[93];
            MCProgramNumber[5] = UDPData[94];
            MCProgramNumber[6] = UDPData[95];
            MCProgramNumber[7] = UDPData[96];

            string ProgramNumber = RemoveSpecialCharacters(Encoding.ASCII.GetString(MCProgramNumber).Trim('\0'));
        }

        public static void ParseProgramName(byte[] UDPData)
        {
            byte[] MCProgramName = new byte[48];
            MCProgramName[0] = UDPData[122];
            MCProgramName[1] = UDPData[123];
            MCProgramName[2] = UDPData[124];
            MCProgramName[3] = UDPData[125];
            MCProgramName[4] = UDPData[126];
            MCProgramName[5] = UDPData[127];
            MCProgramName[6] = UDPData[128];
            MCProgramName[7] = UDPData[129];
            MCProgramName[8] = UDPData[130];
            MCProgramName[9] = UDPData[131];
            MCProgramName[10] = UDPData[132];
            MCProgramName[11] = UDPData[133];
            MCProgramName[12] = UDPData[134];
            MCProgramName[13] = UDPData[135];
            MCProgramName[14] = UDPData[136];
            MCProgramName[15] = UDPData[137];
            MCProgramName[16] = UDPData[138];
            MCProgramName[17] = UDPData[139];
            MCProgramName[18] = UDPData[140];
            MCProgramName[19] = UDPData[141];
            MCProgramName[20] = UDPData[142];
            MCProgramName[21] = UDPData[143];
            MCProgramName[22] = UDPData[144];
            MCProgramName[23] = UDPData[145];
            MCProgramName[24] = UDPData[146];
            MCProgramName[25] = UDPData[147];
            MCProgramName[26] = UDPData[148];
            MCProgramName[27] = UDPData[149];
            MCProgramName[28] = UDPData[150];
            MCProgramName[29] = UDPData[151];
            MCProgramName[30] = UDPData[152];
            MCProgramName[31] = UDPData[153];
            MCProgramName[32] = UDPData[154];
            MCProgramName[33] = UDPData[155];
            MCProgramName[34] = UDPData[156];
            MCProgramName[35] = UDPData[157];
            MCProgramName[36] = UDPData[158];
            MCProgramName[37] = UDPData[159];
            MCProgramName[38] = UDPData[160];
            MCProgramName[39] = UDPData[161];
            MCProgramName[40] = UDPData[162];
            MCProgramName[41] = UDPData[163];
            MCProgramName[42] = UDPData[164];
            MCProgramName[43] = UDPData[165];
            MCProgramName[44] = UDPData[166];
            MCProgramName[45] = UDPData[167];
            MCProgramName[46] = UDPData[168];
            MCProgramName[47] = UDPData[169];

            string ProgramName = RemoveSpecialCharacters((String)Encoding.ASCII.GetString(MCProgramName).Trim('\0'));

        }

        public static void ParseSubProgramNumber(byte[] UDPData)
        {
            byte[] MCSubProgramNumber = new byte[8];
            MCSubProgramNumber[0] = UDPData[171];
            MCSubProgramNumber[1] = UDPData[172];
            MCSubProgramNumber[2] = UDPData[173];
            MCSubProgramNumber[3] = UDPData[174];
            MCSubProgramNumber[4] = UDPData[175];
            MCSubProgramNumber[5] = UDPData[176];
            MCSubProgramNumber[6] = UDPData[177];
            MCSubProgramNumber[7] = UDPData[178];

            string SubProgramNumber = RemoveSpecialCharacters((String)Encoding.ASCII.GetString(MCSubProgramNumber).Trim('\0'));
        }

        public static void ParseSubProgramName(byte[] UDPData)
        {
            byte[] MCSubProgramName = new byte[48];
            MCSubProgramName[0] = UDPData[204];
            MCSubProgramName[1] = UDPData[205];
            MCSubProgramName[2] = UDPData[206];
            MCSubProgramName[3] = UDPData[207];
            MCSubProgramName[4] = UDPData[208];
            MCSubProgramName[5] = UDPData[209];
            MCSubProgramName[6] = UDPData[210];
            MCSubProgramName[7] = UDPData[211];
            MCSubProgramName[8] = UDPData[212];
            MCSubProgramName[9] = UDPData[213];
            MCSubProgramName[10] = UDPData[214];
            MCSubProgramName[11] = UDPData[215];
            MCSubProgramName[12] = UDPData[216];
            MCSubProgramName[13] = UDPData[217];
            MCSubProgramName[14] = UDPData[218];
            MCSubProgramName[15] = UDPData[219];
            MCSubProgramName[16] = UDPData[220];
            MCSubProgramName[17] = UDPData[221];
            MCSubProgramName[18] = UDPData[222];
            MCSubProgramName[19] = UDPData[223];
            MCSubProgramName[20] = UDPData[224];
            MCSubProgramName[21] = UDPData[225];
            MCSubProgramName[22] = UDPData[226];
            MCSubProgramName[23] = UDPData[227];
            MCSubProgramName[24] = UDPData[228];
            MCSubProgramName[25] = UDPData[229];
            MCSubProgramName[26] = UDPData[230];
            MCSubProgramName[27] = UDPData[231];
            MCSubProgramName[28] = UDPData[232];
            MCSubProgramName[29] = UDPData[233];
            MCSubProgramName[30] = UDPData[234];
            MCSubProgramName[31] = UDPData[235];
            MCSubProgramName[32] = UDPData[236];
            MCSubProgramName[33] = UDPData[237];
            MCSubProgramName[34] = UDPData[238];
            MCSubProgramName[35] = UDPData[239];
            MCSubProgramName[36] = UDPData[240];
            MCSubProgramName[37] = UDPData[241];
            MCSubProgramName[38] = UDPData[242];
            MCSubProgramName[29] = UDPData[243];
            MCSubProgramName[40] = UDPData[244];
            MCSubProgramName[41] = UDPData[245];
            MCSubProgramName[42] = UDPData[246];
            MCSubProgramName[43] = UDPData[247];
            MCSubProgramName[44] = UDPData[248];
            MCSubProgramName[45] = UDPData[249];
            MCSubProgramName[46] = UDPData[250];
            MCSubProgramName[47] = UDPData[251];

            string subProgramName = RemoveSpecialCharacters((String)Encoding.ASCII.GetString(MCSubProgramName).Trim('\0'));
        }

        public static void ParseAlarmNumber(byte[] UDPData)
        {
            byte[] MCAlarmNumber = new byte[4];
            MCAlarmNumber[0] = UDPData[55];
            MCAlarmNumber[1] = UDPData[56];
            MCAlarmNumber[2] = UDPData[57];
            MCAlarmNumber[3] = UDPData[58];

            string AlarmNumber = RemoveSpecialCharacters((String)Encoding.ASCII.GetString(MCAlarmNumber).Trim('\0'));
        }

        public static void ParseAlarmMessage(byte[] UDPData)
        {
            byte[] MCAlarmMessage = new byte[48];
            MCAlarmMessage[0] = UDPData[364];
            MCAlarmMessage[1] = UDPData[365];
            MCAlarmMessage[2] = UDPData[366];
            MCAlarmMessage[3] = UDPData[367];
            MCAlarmMessage[4] = UDPData[368];
            MCAlarmMessage[5] = UDPData[369];
            MCAlarmMessage[6] = UDPData[370];
            MCAlarmMessage[7] = UDPData[371];
            MCAlarmMessage[8] = UDPData[372];
            MCAlarmMessage[9] = UDPData[373];
            MCAlarmMessage[10] = UDPData[374];
            MCAlarmMessage[11] = UDPData[375];
            MCAlarmMessage[12] = UDPData[376];
            MCAlarmMessage[13] = UDPData[377];
            MCAlarmMessage[14] = UDPData[378];
            MCAlarmMessage[15] = UDPData[379];
            MCAlarmMessage[16] = UDPData[380];
            MCAlarmMessage[17] = UDPData[381];
            MCAlarmMessage[18] = UDPData[382];
            MCAlarmMessage[19] = UDPData[383];
            MCAlarmMessage[20] = UDPData[384];
            MCAlarmMessage[21] = UDPData[385];
            MCAlarmMessage[22] = UDPData[386];
            MCAlarmMessage[23] = UDPData[387];
            MCAlarmMessage[24] = UDPData[388];
            MCAlarmMessage[25] = UDPData[389];
            MCAlarmMessage[26] = UDPData[390];
            MCAlarmMessage[27] = UDPData[391];
            MCAlarmMessage[28] = UDPData[392];
            MCAlarmMessage[29] = UDPData[393];
            MCAlarmMessage[30] = UDPData[394];
            MCAlarmMessage[31] = UDPData[395];
            MCAlarmMessage[32] = UDPData[396];
            MCAlarmMessage[33] = UDPData[397];
            MCAlarmMessage[34] = UDPData[398];
            MCAlarmMessage[35] = UDPData[399];
            MCAlarmMessage[36] = UDPData[400];
            MCAlarmMessage[37] = UDPData[401];
            MCAlarmMessage[38] = UDPData[402];
            MCAlarmMessage[39] = UDPData[403];
            MCAlarmMessage[40] = UDPData[404];
            MCAlarmMessage[41] = UDPData[405];
            MCAlarmMessage[42] = UDPData[406];
            MCAlarmMessage[43] = UDPData[407];
            MCAlarmMessage[44] = UDPData[408];
            MCAlarmMessage[45] = UDPData[409];
            MCAlarmMessage[46] = UDPData[410];
            MCAlarmMessage[47] = UDPData[410];

            string Alarm = RemoveSpecialCharacters((String)Encoding.ASCII.GetString(MCAlarmMessage).Trim('\0'));
        }

        public static void ParseAlarmColor(byte[] UDPData)
        {
            byte[] MCAlmFor = new byte[8];
            MCAlmFor[0] = UDPData[60];
            MCAlmFor[1] = UDPData[61];
            MCAlmFor[2] = UDPData[62];
            MCAlmFor[3] = UDPData[63];
            MCAlmFor[4] = UDPData[64];
            MCAlmFor[5] = UDPData[65];
            MCAlmFor[6] = UDPData[66];
            MCAlmFor[7] = UDPData[67];

            byte[] MCAlmBck = new byte[8];
            MCAlmBck[0] = UDPData[72];
            MCAlmBck[1] = UDPData[73];
            MCAlmBck[2] = UDPData[74];
            MCAlmBck[3] = UDPData[75];
            MCAlmBck[4] = UDPData[76];
            MCAlmBck[5] = UDPData[77];
            MCAlmBck[6] = UDPData[78];
            MCAlmBck[7] = UDPData[79];

            if (MCAlmFor[0] == 48 && MCAlmFor[1] == 0)
            {
                //No Alarm (Forecolor = 0, next byte is null)
            }
            else
            {
                var af = (String)Encoding.ASCII.GetString(MCAlmFor);
                int i = af.IndexOf('\0');
                if (i >= 0) af = af.Substring(0, i);

                string AlmForColor = (String)af;

                switch (AlmForColor)
                {
                    case "16777215":
                        //White
                        break;

                    case "65535":
                        //Yellow
                        break;

                    case "255":
                        //Red
                        break;

                    case "0":
                        //Black
                        break;
                }
            }

            if (MCAlmBck[0] == 48 && MCAlmBck[1] == 0)
            {
                //No Alarm (Backcolor = 0, next byte is null)
            }
            else
            {
                var ab = (String)Encoding.ASCII.GetString(MCAlmBck);
                int i = ab.IndexOf('\0');
                if (i >= 0) ab = ab.Substring(0, i);

                string alarmBackColor = (String)ab;

                switch (alarmBackColor)
                {
                    case "16711680":
                        //Blue
                        break;

                    case "255":
                        //Red

                        break;

                    case "0":
                        //Black
                        break;
                }
            }
        }

        public static void ParsePartCount(byte[] UDPData)
        {
            string PartCount = "";
            byte[] MCPart = new byte[4];
            MCPart[0] = UDPData[338];
            MCPart[1] = UDPData[339];
            MCPart[2] = UDPData[340];
            MCPart[3] = UDPData[341];

            int i = Encoding.ASCII.GetString(MCPart).IndexOf('\0');

            if (i >= 0)
            {
                PartCount = Encoding.ASCII.GetString(MCPart).Substring(0, i);
            }
        }

        public static void ParseTool(byte[] UDPData)
        {
            byte[] MCTool = new byte[4];
            MCTool[0] = UDPData[274];
            MCTool[1] = UDPData[275];
            MCTool[2] = UDPData[276];
            MCTool[3] = UDPData[277];
            string Tool = RemoveSpecialCharacters((String)Encoding.ASCII.GetString(MCTool));

            int i = Tool.IndexOf('\0');
            if (i >= 0)
            {
                Tool = Tool.Substring(0, i);
            }
        }

        public static string RemoveSpecialCharacters(string input)
        {
            string rtn = input.Replace("\r\n", string.Empty);
            Regex r = new Regex("(?:[^a-z0-9 ]|(?<=['\"])s)", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled);
            return r.Replace(rtn, String.Empty);
        }
    }
}