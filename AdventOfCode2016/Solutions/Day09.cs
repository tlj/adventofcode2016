using System;

namespace AdventOfCode2016.Solutions 
{
    public class Day09 : Base
    {
        public Day09(string inputString)
        {
            Init(inputString);
        }

        public Day09(bool isTest)
        {
            if (isTest)
            {
                Init(Inputs.Day09.testData);
            }
            else
            {
                Init(Inputs.Day09.realData);
            }
        }

        public override void Run()
        {
            base.Run();

            firstResult = Decompress(input, 1, false).Length.ToString();
            Decompress(input, 2, false).Length.ToString();
        }

        public string Decompress(string compressedString, int version, bool inner)
        {
            var compressed = "";
            ulong size = 0;
            for (var i = 0; i < compressedString.Length; i++) {
                if (compressedString[i] == '(') {
                    // Congrats! We are in a marker!
                    var repeatPos = "";
                    var repeatCount = "";
                    var hitX = false;                     
                    
                    var j = i + 1;
                    while (compressedString.Length > j && compressedString[j] != ')') {
                        // Get the marker data
                        if (compressedString[j] == 'x') {
                            // lol
                            hitX = true;
                        } else {
                            if (hitX) {
                                repeatCount += compressedString[j];
                            } else {
                                repeatPos += compressedString[j];
                            }
                        }
                        j++;
                    }
                    i = j;                    
                    i++;
                    var repeatSequence = "";
                    // Find the sequence to repeat
                    for (var k = 0; k < int.Parse(repeatPos); k++) {
                        repeatSequence += compressedString[i + k];
                    }
                    // For compression v2 we need to decompress the sequences within the sequence as well
                    if (version == 2) {
                        repeatSequence = Decompress(repeatSequence, version, true);
                    }
                    // Add all the repeats of the sequence
                    for (var l = 0; l < int.Parse(repeatCount); l++) {
                        if (version == 1 || inner) {
                            // Add the sequence so we can either return it or keep decompressing it
                            compressed += repeatSequence;
                        } else if (version == 2) {
                            // Since version 2 decompresses a lot more than version 1 we can't decompress
                            //  to memory directly. So we just get the size of it. We should probably write
                            //  it to disk as well, but my disk doesn't have enough space :( 
                            size += Convert.ToUInt64(repeatSequence.Length);
                        }
                    }
                    i = i + int.Parse(repeatPos) - 1;
                } else {
                    // Not in a sequence
                    compressed += compressedString[i];
                    if (version == 2) {
                        size++;
                    }
                }
            }
            secondResult = size.ToString();
            return compressed;
        }
    }
}