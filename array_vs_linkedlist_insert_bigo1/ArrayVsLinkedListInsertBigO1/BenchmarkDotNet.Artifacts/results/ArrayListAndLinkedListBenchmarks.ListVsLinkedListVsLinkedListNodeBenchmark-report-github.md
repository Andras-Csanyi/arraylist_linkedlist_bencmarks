``` ini

BenchmarkDotNet=v0.13.1, OS=ubuntu 20.04
AMD EPYC 7282, 1 CPU, 8 logical and 8 physical cores
.NET SDK=6.0.300
  [Host]   : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT
  ShortRun : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|                         Method | AmountOfChanges | SizeOfAppendedArrays | ListSize |             Mean |            Error |          StdDev |           Median |              Min |              Max |    Allocated |
|------------------------------- |---------------- |--------------------- |--------- |-----------------:|-----------------:|----------------:|-----------------:|-----------------:|-----------------:|-------------:|
| **AddChangesToLinkedListOneByOne** |             **100** |                  **100** |    **10000** |         **4.319 ms** |         **4.466 ms** |       **0.2448 ms** |         **4.320 ms** |         **4.074 ms** |         **4.563 ms** |    **480,003 B** |
|       AddChangesToListOneByOne |             100 |                  100 |    10000 |     1,497.844 ms |     4,501.847 ms |     246.7614 ms |     1,504.771 ms |     1,247.692 ms |     1,741.069 ms |         51 B |
|       AddChangesToListAsRanges |             100 |                  100 |    10000 |       158.909 ms |       506.517 ms |      27.7639 ms |       156.082 ms |       132.667 ms |       187.978 ms |         13 B |
|    AddChangesToLLNodesAsRanges |             100 |                  100 |    10000 |         3.191 ms |         3.157 ms |       0.1730 ms |         3.244 ms |         2.998 ms |         3.331 ms |    400,013 B |
| **AddChangesToLinkedListOneByOne** |             **200** |                  **100** |    **10000** |         **7.200 ms** |         **5.591 ms** |       **0.3065 ms** |         **7.169 ms** |         **6.911 ms** |         **7.521 ms** |    **960,006 B** |
|       AddChangesToListOneByOne |             200 |                  100 |    10000 |     1,176.965 ms |     1,642.482 ms |      90.0300 ms |     1,194.795 ms |     1,079.354 ms |     1,256.746 ms |  1,398,712 B |
|       AddChangesToListAsRanges |             200 |                  100 |    10000 |       298.058 ms |     1,061.301 ms |      58.1735 ms |       286.586 ms |       246.475 ms |       361.113 ms |         26 B |
|    AddChangesToLLNodesAsRanges |             200 |                  100 |    10000 |         3.120 ms |         7.177 ms |       0.3934 ms |         3.326 ms |         2.667 ms |         3.368 ms |    800,035 B |
| **AddChangesToLinkedListOneByOne** |             **300** |                  **100** |    **10000** |         **9.898 ms** |       **144.832 ms** |       **7.9387 ms** |         **5.667 ms** |         **4.972 ms** |        **19.056 ms** |  **1,440,003 B** |
|       AddChangesToListOneByOne |             300 |                  100 |    10000 |     2,140.295 ms |    15,748.430 ms |     863.2246 ms |     1,711.062 ms |     1,575.826 ms |     3,133.998 ms |        408 B |
|       AddChangesToListAsRanges |             300 |                  100 |    10000 |       321.032 ms |     2,158.810 ms |     118.3317 ms |       312.076 ms |       207.433 ms |       443.588 ms |  2,097,162 B |
|    AddChangesToLLNodesAsRanges |             300 |                  100 |    10000 |         3.960 ms |         7.277 ms |       0.3989 ms |         4.143 ms |         3.502 ms |         4.234 ms |  1,200,006 B |
| **AddChangesToLinkedListOneByOne** |             **400** |                  **100** |    **10000** |         **6.834 ms** |        **13.306 ms** |       **0.7293 ms** |         **6.805 ms** |         **6.119 ms** |         **7.577 ms** |  **1,920,007 B** |
|       AddChangesToListOneByOne |             400 |                  100 |    10000 |     2,414.852 ms |     7,934.704 ms |     434.9279 ms |     2,415.215 ms |     1,979.743 ms |     2,849.599 ms |        408 B |
|       AddChangesToListAsRanges |             400 |                  100 |    10000 |       837.838 ms |     1,721.118 ms |      94.3403 ms |       848.815 ms |       738.490 ms |       926.210 ms |         51 B |
|    AddChangesToLLNodesAsRanges |             400 |                  100 |    10000 |         4.997 ms |         3.565 ms |       0.1954 ms |         5.043 ms |         4.783 ms |         5.166 ms |  1,600,006 B |
| **AddChangesToLinkedListOneByOne** |             **500** |                  **100** |    **10000** |         **8.619 ms** |        **26.495 ms** |       **1.4523 ms** |         **9.409 ms** |         **6.943 ms** |         **9.505 ms** |  **2,400,006 B** |
|       AddChangesToListOneByOne |             500 |                  100 |    10000 |     3,801.739 ms |    11,555.330 ms |     633.3866 ms |     3,792.459 ms |     3,173.044 ms |     4,439.715 ms |        408 B |
|       AddChangesToListAsRanges |             500 |                  100 |    10000 |     1,287.202 ms |     4,185.405 ms |     229.4162 ms |     1,266.942 ms |     1,068.588 ms |     1,526.076 ms |         51 B |
|    AddChangesToLLNodesAsRanges |             500 |                  100 |    10000 |         5.905 ms |         5.238 ms |       0.2871 ms |         5.950 ms |         5.597 ms |         6.166 ms |  2,000,006 B |
| **AddChangesToLinkedListOneByOne** |            **1000** |                  **100** |    **10000** |        **18.636 ms** |        **33.578 ms** |       **1.8405 ms** |        **18.178 ms** |        **17.067 ms** |        **20.662 ms** |  **4,800,026 B** |
|       AddChangesToListOneByOne |            1000 |                  100 |    10000 |    15,204.707 ms |    68,839.457 ms |   3,773.3229 ms |    14,777.190 ms |    11,663.351 ms |    19,173.581 ms |        408 B |
|       AddChangesToListAsRanges |            1000 |                  100 |    10000 |     4,595.169 ms |    13,106.219 ms |     718.3961 ms |     4,622.635 ms |     3,863.434 ms |     5,299.438 ms |         27 B |
|    AddChangesToLLNodesAsRanges |            1000 |                  100 |    10000 |        11.090 ms |         9.332 ms |       0.5115 ms |        11.060 ms |        10.595 ms |        11.617 ms |  4,000,013 B |
| **AddChangesToLinkedListOneByOne** |            **2000** |                  **100** |    **10000** |        **58.877 ms** |        **97.142 ms** |       **5.3247 ms** |        **57.369 ms** |        **54.468 ms** |        **64.793 ms** |  **9,600,051 B** |
|       AddChangesToListOneByOne |            2000 |                  100 |    10000 |    91,169.327 ms |   749,377.597 ms |  41,075.9148 ms |    88,663.766 ms |    51,403.546 ms |   133,440.669 ms |        552 B |
|       AddChangesToListAsRanges |            2000 |                  100 |    10000 |    17,383.059 ms |    39,869.088 ms |   2,185.3592 ms |    17,350.877 ms |    15,213.968 ms |    19,584.331 ms |         93 B |
|    AddChangesToLLNodesAsRanges |            2000 |                  100 |    10000 |        52.584 ms |        59.855 ms |       3.2809 ms |        50.708 ms |        50.670 ms |        56.372 ms |  8,000,051 B |
| **AddChangesToLinkedListOneByOne** |            **3000** |                  **100** |    **10000** |       **156.797 ms** |       **259.583 ms** |      **14.2286 ms** |       **152.366 ms** |       **145.311 ms** |       **172.714 ms** | **14,400,051 B** |
|       AddChangesToListOneByOne |            3000 |                  100 |    10000 |   186,763.299 ms | 1,212,748.522 ms |  66,474.8387 ms |   187,296.399 ms |   120,023.513 ms |   252,969.984 ms |         72 B |
|       AddChangesToListAsRanges |            3000 |                  100 |    10000 |    34,064.359 ms |   105,395.307 ms |   5,777.0724 ms |    34,451.749 ms |    28,103.341 ms |    39,637.987 ms |         93 B |
|    AddChangesToLLNodesAsRanges |            3000 |                  100 |    10000 |        68.665 ms |        60.133 ms |       3.2961 ms |        69.924 ms |        64.924 ms |        71.145 ms | 12,000,051 B |
| **AddChangesToLinkedListOneByOne** |            **4000** |                  **100** |    **10000** |       **155.940 ms** |        **82.165 ms** |       **4.5037 ms** |       **155.092 ms** |       **151.921 ms** |       **160.808 ms** | **19,200,163 B** |
|       AddChangesToListOneByOne |            4000 |                  100 |    10000 |   337,444.386 ms | 1,654,214.549 ms |  90,673.0814 ms |   323,907.212 ms |   254,300.981 ms |   434,124.965 ms |        552 B |
|       AddChangesToListAsRanges |            4000 |                  100 |    10000 |    50,044.155 ms |   113,172.734 ms |   6,203.3795 ms |    48,607.586 ms |    44,685.095 ms |    56,839.784 ms |         69 B |
|    AddChangesToLLNodesAsRanges |            4000 |                  100 |    10000 |       181.203 ms |       193.616 ms |      10.6127 ms |       177.859 ms |       172.666 ms |       193.085 ms | 16,000,680 B |
| **AddChangesToLinkedListOneByOne** |            **5000** |                  **100** |    **10000** |       **272.400 ms** |       **945.690 ms** |      **51.8365 ms** |       **280.049 ms** |       **217.164 ms** |       **319.987 ms** | **24,000,163 B** |
|       AddChangesToListOneByOne |            5000 |                  100 |    10000 |   470,648.404 ms | 2,595,925.180 ms | 142,291.4187 ms |   464,369.285 ms |   331,600.491 ms |   615,975.436 ms | 33,554,996 B |
|       AddChangesToListAsRanges |            5000 |                  100 |    10000 |    68,689.733 ms |   238,147.667 ms |  13,053.6772 ms |    68,332.648 ms |    55,818.263 ms |    81,918.290 ms |         51 B |
|    AddChangesToLLNodesAsRanges |            5000 |                  100 |    10000 |       245.503 ms |       773.276 ms |      42.3859 ms |       245.429 ms |       203.154 ms |       287.926 ms | 20,000,048 B |
| **AddChangesToLinkedListOneByOne** |           **10000** |                  **100** |    **10000** |     **1,057.627 ms** |    **15,838.929 ms** |     **868.1852 ms** |       **584.119 ms** |       **529.143 ms** |     **2,059.618 ms** | **48,001,387 B** |
|       AddChangesToListOneByOne |           10000 |                  100 |    10000 | 1,677,680.943 ms | 8,106,651.224 ms | 444,352.9083 ms | 1,670,419.527 ms | 1,237,003.244 ms | 2,125,620.059 ms | 67,109,824 B |
|       AddChangesToListAsRanges |           10000 |                  100 |    10000 |   167,542.256 ms |   962,901.976 ms |  52,779.9065 ms |   176,982.138 ms |   110,679.386 ms |   214,965.243 ms |         93 B |
|    AddChangesToLLNodesAsRanges |           10000 |                  100 |    10000 |       172.065 ms |     1,819.660 ms |      99.7417 ms |       140.335 ms |        92.049 ms |       283.812 ms | 40,000,408 B |
| **AddChangesToLinkedListOneByOne** |           **15000** |                  **100** |    **10000** |     **1,272.350 ms** |     **1,413.048 ms** |      **77.4539 ms** |     **1,269.570 ms** |     **1,196.324 ms** |     **1,351.157 ms** | **72,000,272 B** |
|       AddChangesToListOneByOne |           15000 |                  100 |    10000 | 1,079,820.543 ms | 5,088,481.174 ms | 278,916.8234 ms | 1,057,266.468 ms |   812,865.520 ms | 1,369,329.642 ms |        816 B |
|       AddChangesToListAsRanges |           15000 |                  100 |    10000 |   166,766.835 ms | 1,073,249.395 ms |  58,828.4209 ms |   165,553.072 ms |   108,554.688 ms |   226,192.746 ms |         93 B |
|    AddChangesToLLNodesAsRanges |           15000 |                  100 |    10000 |       247.001 ms |       598.514 ms |      32.8066 ms |       233.553 ms |       223.055 ms |       284.395 ms | 60,000,272 B |
| **AddChangesToLinkedListOneByOne** |           **20000** |                  **100** |    **10000** |       **581.525 ms** |     **1,326.356 ms** |      **72.7021 ms** |       **621.331 ms** |       **497.613 ms** |       **625.632 ms** | **96,001,372 B** |
|       AddChangesToListOneByOne |           20000 |                  100 |    10000 | 1,120,799.038 ms | 5,788,926.326 ms | 317,310.5858 ms | 1,120,355.311 ms |   803,710.548 ms | 1,438,331.254 ms |        816 B |
|       AddChangesToListAsRanges |           20000 |                  100 |    10000 |   172,870.537 ms | 1,287,893.127 ms |  70,593.7681 ms |   172,547.020 ms |   102,439.084 ms |   243,625.508 ms |         93 B |
|    AddChangesToLLNodesAsRanges |           20000 |                  100 |    10000 |       663.092 ms |     9,630.072 ms |     527.8568 ms |       466.825 ms |       261.482 ms |     1,260.967 ms | 80,000,816 B |
