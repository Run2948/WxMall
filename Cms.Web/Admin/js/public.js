<!--
// JavaScript Document
//返回汉字的拼音的第一个字母
function GetPY(str)
{
    var ret = '';
    for(var i=0,len=str.length;i<len;i++)
    {
        var ch = str.charAt(i);
        ret += CheckCh(ch);
    }
    
    return ret;
}

function CheckAll(form)
{
  for (var i=0;i<form.elements.length;i++)
    {
    var e = form.elements[i];
    if (e.Name != "chkAll")
       e.checked = form.chkAll.checked;
    }
}


function CheckCh(ch)
{
    var uni = ch.charCodeAt(0);
    var strChineseFirstPY = 'ydyqsxmwzssxjbymgcczqpssqbycdscdqldylybssjgyzzjjfkcclzdhwdwzjljpfyynwjjtmyhzwzhflzppqhgscyyynjqyxxgjhhsdsjnkktmomlcrxypsnqseccqzggllyjlmyzzsecykyyhqwjssggyxyzyjwwkdjhychmyxjtlxjyqbyxzldwrdjrwysrldzjpcbzjjbrcftleczstzfxxzhtrqhybdlyczssymmrfmyqzpwwjjyfcrwfdfzqpyddwyxkyjawjffxypsftzyhhyzyswcjyxsclcxxwzzxnbgnnxbxlzszsbsgpysyzdhmdzbqbzcwdzzyytzhbtsyybzgntnxqywqskbphhlxgybfmjebjhhgqtjcysxstkzhlyckglysmzxyalmeldccxgzyrjxsdltyzcqkcnnjwhjtzzcqljststbnxbtyxceqxgkwjyflzqlyhyxspsfxlmpbysxxxydjczylllsjxfhjxpjbtffyabyxbhzzbjyzlwlczggbtssmdtjzxpthyqtgljscqfzkjzjqnlzwlslhdzbwjncjzyzsqqycqyrzcjjwybrtwpyftwexcskdzctbzhyzzyyjxzcffzzmjyxxsdzzottbzlqwfckszsxfyrlnyjmbdthjxsqqccsbxyytsyfbxdztgbcnslcyzzpsazyzzscjcshzqydxlbpjllmqxtydzxsqjtzpxlcglqtzwjbhctsyjsfxyejjtlbgxsxjmyjqqpfzasyjntydjxkjcdjszcbartdclyjqmwnqnclllkbybzzsyhqqltwlccxtxllzntylnewyzyxczxxgrkrmtcndnjtsyyssdqdghsdbjghrwrqlybglxhlgtgxbqjdzpyjsjyjctmrnymgrzjczgjmzmgxmpryxkjnymsgmzjymkmfxmldtgfbhcjhkylpfmdxlqjjsmtqgzsjlqdldgjycalcmzcsdjllnxdjffffjczfmzffpfkhkgdpsxktacjdhhzddcrrcfqyjkqccwjdxhwjlyllzgcfcqdsmlzpbjjplsbcjggdckkdezsqcckjgcgkdjtjdlzycxklqscgjcltfpcqczgwpjdqyzjjbyjhsjdzwgfsjgzkqcczllpspkjgqjhzzljplgjgjjthjjyjzczmlzlyqbgjwmljkxzdznjqsyzmljlljkywxmkjlhskjgbmclyymkxjqlbmllkmdxxkwyxyslmlpsjqqjqxyxfjtjdxmxxllcxqbsyjbgwymbggbcyxpjygpepfgdjgbhbnsqjyzjkjkhxqfgqzkfhygkhdkllsdjqxpqykybnqsxqnszswhbsxwhxwbzzxdmnsjbsbkbbzklylxgwxdrwyqzmywsjqlcjxxjxkjeqxscyetlzhlyyysdzpaqyzcmtlshtzcfyzyxyljsdcjqagyslcqlyyyshmrqqkldxzscsssydycjysfsjbfrsszqsbxxpxjysdrckgjlgdkzjzbdktcsyqpyhstcldjdhmxmcgxyzhjddtmhltxzxylymohyjcltyfbqqxpfbdfhhtksqhzyywcnxxcrwhowgyjlegwdqcwgfjycsntmytolbygwqwesjpwnmlrydzsztxyqpzgcwxhngpyxshmyqjxztdppbfyhzhtjyfdzwkgkzbldntsxhqeegzzylzmmzyjzgxzxkhkstxnxxwylyapsthxdwhzympxagkydxbhnhxkdpjnmyhylpmgocslnzhkxxlpzzlbmlsfbhhgygyyggbhscyaqtywlxtzqcezydqdqmmhtkllszhlsjzwfyhqswscwlqazynytlsxthaznkzzszzlaxxzwwctgqqtddyztcchyqzflxpslzygpzsznglndqtbdlxgtctajdkywnsyzljhhzzcwnyyzywmhychhyxhjkzwsxhzyxlyskqyspslyzwmyppkbyglkzhtyxaxqsyshxasmchkdscrswjpwxsgzjlwwschsjhsqnhcsegndaqtbaalzzmsstdqjcjktscjaxplggxhhgxxzcxpdmmhldgtybysjmxhmrcpxxjzckzxshmlqxxtthxwzfkhcczdytcjyxqhlxdhypjqxylsyydzozjnyxqezysqyayxwypdgxddxsppyzndltwrhxydxzzjhtcxmczlhpyyyymhzllhnxmylllmdcppxhmxdkycyrdltxjchhzzxzlcclylnzshzjzzlnnrlwhyqsnjhxyntttkyjpychhyegkcttwlgqrlggtgtygyhpyhylqyqgcwyqkpyyyttttlhyhlltyttsplkyzxgzwgpydsszzdqxskcqnmjjzzbxyqmjrtffbtkhzkbxljjkdxjtlbwfzpptkqtztgpdgntpjyfalqmkgxbdclzfhzclllladpmxdjhlcclgyhdzfgyddgcyyfgydxkssebdhykdkdkhnaxxybpbyyhxzqgaffqyjxdmljcsqzllpchbsxgjyndybyqspzwjlzksddtactbxzdyzypjzqsjnkktknjdjgyypgtlfyqkasdntcyhblwdzhbbydwjrygkzyheyyfjmsdtyfzjjhgcxplxhldwxxjkytcyksssmtwcttqzlpbszdzwzxgzagyktywxlhlspbclloqmmzsslcmbjcszzkydczjgqqdsmcytzqqlwzqzxssfpttfqmddzdshdtdwfhtdyzjyqjqkypbdjyyxtljhdrqxxxhaydhrjlklytwhllrllrcxylbwsrszzsymkzzhhkyhxksmdsydycjpbzbsqlfcxxxnxkxwywsdzyqoggqmmyhcdzttfjyybgstttybykjdhkyxbelhtypjqnfxfdykzhqkzbyjtzbxhfdxkdaswtawajldyjsfhbldnntnqjtjnchxfjsrfwhzfmdryjyjwzpdjkzyjympcyznynxfbytfyfwygdbnzzzdnytxzemmqbsqehxfzmbmflzzsrxymjgsxwzjsprydjsjgxhjjgljjynzzjxhgxkymlpyyycxytwqzswhwlyrjlpxslsxmfswwklctnxnynpsjszhdzeptxmyywxyysywlxjqzqxzdcleeelmcpjpclwbxsqhfwwtffjtnqjhjqdxhwlbyznfjlalkyyjldxhhycstyywnrjyxywtrmdrqhwqcmfjdyzmhmyyxjwmyzqzxtlmrspwwchaqbxygzypxyyrrclmpymgksjszysrmyjsnxtplnbappypylxyyzkynldzyjzcznnlmzhharqmpgwqtzmxxmllhgdzxyhxkyxycjmffyyhjfsbssqlxxndycannmtcjcyprrnytyqnyymbmsxndlylysljrlxysxqmllyzlzjjjkyzzcsfbzxxmstbjgnxyzhlxnmcwscyzyfzlxbrnnnylbnrtgzqysatswryhyjzmzdhzgzdwybsscskxsyhytxxgcqgxzzshyxjscrhmkkbxczjyjymkqhzjfnbhmqhysnjnzybknqmclgqhwlznzswxkhljhyybqlbfcdsxdldspfzpskjyzwzxzddxjsmmegjscssmgclxxkyyylnypwwwgydkzjgggzggsycknjwnjpcxbjjtqtjwdsspjxzxnzxumelpxfsxtllxcljxjjljzxctpswxlydhlyqrwhsycsqyybyaywjjjqfwqcqqcjqgxaldbzzyjgkgxpltzyfxjltpadkyqhpmatlcpdckbmtxybhklenxdleegqdymsawhzmljtwygxlyqzljeeyybqqffnlyxrdsctgjgxyynkllyqkcctlhjlqmkkzgcyygllljdzgydhzwxpysjbzkdzgyzzhywyfqytyzszyezzlymhjjhtsmqwyzlkyywzcsrkqytltdxwctyjklwsqzwbdcqyncjsrszjlkcdcdtlzzzacqqzzddxyplxzbqjylzlllqddzqjyjyjzyxnyyynyjxkxdazwyrdljyyyrjlxlldyxjcywywnqcclddnyyynyckczhxxcclgzqjgkwppcqqjysbzzxyjsqpxjpzbsbdsfnsfpzxhdwztdwpptflzzbzdmyypqjrsdzsqzsqxbdgcpzswdwcsqzgmdhzxmwwfybpdgphtmjthzsmmbgzmbzjcfzwfzbbzmqcfmbdmcjxlgpnjbbxgyhyyjgptzgzmqbqtcgyxjxlwzkydpdymgcftpfxyztzxdzxtgkmtybbclbjaskytssqyymszxfjewlxllszbqjjjaklylxlycctsxmcwfkkkbsxlllljyxtyltjyytdpjhnhnnkbyqnfqyyzbyyessessgdyhfhwtcjbsdzztfdmxhcnjzymqwsryjdzjqpdqbbstjggfbkjbxtgqhngwjxjgdllthzhhyyyyyysxwtyyyccbdbpypzycczyjpzywcbdlfwzcwjdxxhyhlhwzzxjtczlcdpxujczzzlyxjjtxphfxwpywxzptdzzbdzcyhjhmlxbqxsbylrdtgjrrcttthytczwmxfytwwzcwjwxjywcskybzscctzqnhxnwxxkhkfhtswoccjybcmpzzykbnnzpbzhhzdlsyddytyfjpxyngfxbyqxcbhxcpsxtyzdmkysnxsxlhkmzxlyhdhkwhxxsskqyhhcjyxglhzxcsnhekdtgzxqypkdhextykcnymyyypkqyyykxzlthjqtbyqhxbmyhsqckwwyllhcyylnneqxqwmcfbdccmljggxdqktlxkgnqcdgzjwyjjlyhhqtttnwchmxcxwhwszjydjccdbqcdgdnyxzthcqrxcbhztqcbxwgqwyybxhmbymyqtyexmqkyaqyrgyzslfykkqhyssqyshjgjcnxkzycxsbxyxhyylstycxqthysmgscpmmgcccccmtztasmgqzjhklosqylswtmxsyqkdzljqqyplsycztcqqpbbqjzclpkhqzyyxxdtddtsjcxffllchqxmjlwcjcxtspycxndtjshjwxdqqjskxyamylsjhmlalykxcyydmnmdqmxmcznncybzkkyflmchcmlhxrcjjhsylnmtjzgzgywjxsrxcwjgjqhqzdqjdcjjzkjkgdzqgjjyjylxzxxcdqhhheytmhlfsbdjsyyshfystczqlpbdrfrztzykywhszyqkwdqzrkmsynbcrxqbjyfazpzzedzcjywbcjwhyjbqszywryszptdkzpfpbnztklqyhbbzpnpptyzzybqnydcpjmmcycqmcyfzzdcmnlfpbplngqjtbttnjzpzbbznjkljqylnbzqhksjznggqszzkyxshpzsnbcgzkddzqanzhjkdrtlzlswjljzlywtjndjzjhxyayncbgtzcssqmnjpjytyswxzfkwjqtkhtzplbhsnjzsyzbwzzzzlsylsbjhdwwqpslmmfbjdwaqyztcjtbnnwzxqxcdslqgdsdpdzhjtqqpswlyyjzlgyxyzlctcbjtktyczjtqkbsjlgmgzdmcsgpynjzyqyyknxrpwszxmtncszzyxybyhyzaxywqcjtllckjjtjhgdxdxyqyzzbywdlwqcglzgjgqrqzczssbcrpcskydznxjsqgxssjmydnstztpbdltkzwxqwqtzexnqczgwezkssbybrtssslccgbpszqszlccglllzxhzqthczmqgyzqznmcocszjmmzsqpjygqljyjppldxrgzyxccsxhshgtznlzwzkjcxtcfcjxlbmqbczzwpqdnhxljcthyzlgylnlszzpcxdscqqhjqksxzpbajyemsmjtzdxlcjyryynwjbngzztmjxltbslyrzpylsscnxphllhyllqqzqlxymrsycxzlmmczltzsdwtjjllnzggqxpfskygyghbfzpdkmwghcxmsgdxjmcjzdycabxjdlnbcdqygskydqtxdjjyxmszqazdzfslqxyjsjzylbtxxwxqqzbjzufbblylwdsljhxjyzjwtdjczfqzqzzdzsxzzqlzcdzfjhyspympqzmlpplffxjjnzzylsjeyqzfpfzksywjjjhrdjzzxtxxglghydxcskyswmmzcwybazbjkshfhjcxmhfqhyxxyzftsjyzfxyxpzlchmzmbxhzzsxyfymncwdabazlxktcshhxkxjjzjsthygxsxyyhhhjwxkzxssbzzwhhhcwtzzzpjxsnxqqjgzyzywllcwxzfxxyxyhxmkyyswsqmnlnaycyspmjkhwcqhylajjmzxhmmcnzhbhxclxtjpltxyjhdyylttxfszhyxxsjbjyayrsmxyplckduyhlxrlnllstyzyyqygyhhsccsmzctzqxkyqfpyyrpfflkquntszllzmwwtcqqyzwtllmlmpwmbzsstzrbpddtlqjjbxzcsrzqqygwcsxfwzlxccrszdzmcyggdzqsgtjswljmymmzyhfbjdgyxccpshxnzcsbsjyjgjmppwaffyfnxhyzxzylremzgzcyzsszdlljcsqfnxzkptxzgxjjgfmyyysnbtylbnlhpfzdcyfbmgqrrssszxysgtzrnydzzcdgpjafjfzknzblczszpsgcycjszlmlrszbzzldlsllysxsqzqlyxzlskkbrxbrbzcycxzzzeeyfgklzlyyhgzsgzlfjhgtgwkraajyzkzqtsshjjxdcyzuyjlzyrzdqqhgjzxsszbykjpbfrtjxllfqwjhylqtymblpzdxtzygbdhzzrbgxhwnjtjxlkscfsmwlsdqysjtxkzscfwjlbxftzlljzllqblsqmqqcgczfpbphzczjlpyyggdtgwdcfczqyyyqyssclxzsklzzzgffcqnwglhqyzjjczlqzzyjpjzzbpdccmhjgxdqdgdlzqmfgpsytsdyfwwdjzjysxyyczcyhzwpbykxrylybhkjksfxtzjmmckhlltnyymsyxyzpyjqycsycwmtjjkqyrhllqxpsgtlyycljscpxjyzfnmlrgjjtyzbxyzmsjyjhhfzqmsyxrszcwtlrtqzsstkxgqkgsptgcznjsjcqcxhmxggztqydjkzdlbzsxjlhyqgggthqszpyhjhhgyygkggcwjzzylczlxqsftgzslllmljskctbllzzszmmnytpzsxqhjcjyqxyzxzqzcpshkzzysxcdfgmwqrllqxrfztlystctmjcxjjxhjnxtnrztzfqyhqgllgcxszsjdjljcydsjtlnyxhszxcgjzyqpylfhdjsbpcczhjjjqzjqdybssllcmyttmqtbhjqnnygkyrqyqmzgcjkpdcgmyzhqllsllclmholzgdyyfzsljcqzlylzqjeshnylljxgjxlysyyyxnbzljsszcqqcjyllzltjyllzllbnylgqchxyyxoxcxqkyjxxxyklxsxxyqxcykqxqcsgyxxyqxygytqohxhxpyxxxulcyeychzzcbwqbbwjqzscszsslzylkdesjzwmymcytsdsxxscjpqqsqylyyzycmdjdzywcbtjsydjkcyddjlbdjjsodzysyxqqyxdhhgqqyqhdyxwgmmmajdybbbppbcmuupljzsmtxerxjmhqnutpjdcbssmssstkjtssmmtrcplzszmlqdsdmjmqpnqdxcfynbfsdqxyxhyaykqyddlqyyysszbydslntfqtzqpzmchdhczcwfdxtmyqsphqyyxsrgjcwtjtzzqmgwjjtjhtqjbbhwzpxxhyqfxxqywyyhyscdydhhqmnmtmwcpbszppzzglmzfollcfwhmmsjzttdhzzyffytzzgzyskyjxqyjzqbhmbzzlyghgfmshpzfzsnclpbqsnjxzslxxfpmtyjygbxlldlxpzjyzjyhhzcywhjylsjexfszzywxkzjluydtmlymqjpwxyhxsktqjezrpxxzhhmhwqpwqlyjjqjjzszcphjlchhnxjlqwzjhbmzyxbdhhypzlhlhlgfwlchyytlhjxcjmscpxstkpnhqxsrtyxxtesyjctlsslstdlllwwyhdhrjzsfgxtsyczynyhtdhwjslhtzdqdjzxxqhgyltzphcsqfclnjtclzpfstpdynylgmjllycqhysshchylhqyqtmzypbywrfqykqsyslzdqjmpxyyssrhzjnywtqdfzbwwtwwrxcwhgyhxmkmyyyqmsmzhngcepmlqqmtcwctmmpxjpjjhfxyyzsxzhtybmstsyjttqqqyylhynpyqzlcyzhzwsmylkfjxlwgxypjytysyxymzckttwlksmzsylmpwlzwxwqzssaqsyxyrhssntsrapxcpwcmgdxhxzdzyfjhgzttsbjhgyzszysmyclllxbtyxhbbzjkssdmalxhycfygmqypjycqxjllljgslzgqlycjcczotyxmtmttllwtgpxymzmklpszzzxhkqysxctyjzyhxshyxzkxlzwpsqpyhjwpjpwxqqylxsdhmrslzzyzwttcyxyszzshbsccstplwsscjchnlcgchssphylhfhhxjsxyllnylszdhzxylsxlwzykcldyaxzcmddyspjtqjzlnwqpssswctstszlblnxsmnyymjqbqhrzwtyydchqlxkpzwbgqybkfcmzwpzllyylszydwhxpsbcmljbscgbhxlqhyrljxyswxwxzsldfhlslynjlzyflyjycdrjlfsyzfsllcqyqfgjyhyxzlylmstdjcyhbzllnwlxxygyyhsmgdhxxhhlzzjzxczzzcyqzfngwpylcpkpyypmclqkdgxzggwqbdxzzkzfbxxlzxjtpjpttbytszzdwslchzhsltyxhqlhyxxxyyzyswtxzkhlxzxzpyhgchkcfsyhutjrlxfjxptztwhplyxfcrhxshxkyxxyhzqdxqwulhyhmjtbflkhtxcwhjfwjcfpqryqxcyyyqygrpywsgsungwchkzdxyflxxhjjbyzwtsxxncyjjymswzjqrmhxzwfqsylzjzgbhynslbgttcsybyxxwxyhxyyxnsqyxmqywrgyqlxbbzljsylpsytjzyhyzawlrorjmksczjxxxyxchdyxryxxjdtsqfxlyltsffyxlmtyjmjuyyyxltzcsxqzqhzxlyyxzhdnbrxxxjctyhlbrlmbrllaxkyllljlyxxlycrylcjtgjcmtlzllcyzzpzpcyawhjjfybdyyzsmpckzdqyqpbpcjpdcyzmdpbcyydycnnplmtmlrmfmmgwyzbsjgygsmzqqqztxmkqwgxllpjgzbqcdjjjfpkjkcxbljmswmdtqjxldlppbxcwrcqfbfqjczahzgmykphyyhzykndkzmbpjyxpxyhlfpnyygxjdbkxnxhjmzjxstrstldxskzysybzxjlxyslbzyslhxjpfxpqnbylljqkygzmcyzzymccslclhzfwfwyxzmwsxtynxjhpyymcyspmhysmydyshqyzchmjjmzcaagcfjbbhplyzylxxsdjgxdhkxxtxxnbhrmlyjsltxmrhnlxqjxyzllyswqgdlbjhdcgjyqycmhwfmjybmbyjyjwymdpwhxqldygpdfxxbcgjspckrssyzjmslbzzjfljjjlgxzgyxyxlszqyxbexyxhgcxbpldyhwettwwcjmbtxchxyqxllxflyxlljlssfwdpzsmyjclmwytczpchqekcqbwlcqydplqppqzqfjqdjhymmcxtxdrmjwrhxcjzylqxdyynhyyhrslsrsywwzjymtltllgtqcjzyabtckzcjyccqljzqxalmzyhywlwdxzxqdllqshgpjfjljhjabcqzdjgtkhsstcyjlpswzlxzxrwgldlzrlzxtgsllllzlyxxwgdzygbdphzpbrlwsxqbpfdwofmwhlypcbjccldmbzpbzzlcyqxldomzblzwpdwyygdstthcsqsccrsssyslfybfntyjszdfndpdhdzzmbblslcmyffgtjjqwftmtpjwfnlbzcmmjtgbdzlqlpyfhyymjylsdchdzjwjcctljcldtljjcpddsqdsszybndbjlggjzxsxnlycybjxqycbylzcfzppgkcxzdzfztjjfjsjxzbnzyjqttyjyhtyczhymdjxttmpxsplzcdwslshxypzgtfmlcjtycbpmgdkwycyzcdszzyhflyctygwhkjyylsjcxgywjcbllcsnddbtzbsclyzczzssqdllmqyyhfslqllxftyhabxgwnywyypllsdldllbjcyxjzmlhljdxyyqytdlllbugbfdfbbqjzzmdpjhgclgmjjpgaehhbwcqxaxhhhzchxyphjaxhlphjpgpzjqcqzgjjzzuzdmqyybzzphyhybwhazyjhykfgdpfqsdlzmljxkxgalxzdaglmdgxmwzqyxxdxxpfdmmssympfmdmmkxksyzyshdzkxsysmmzzzmsydnzzczxfplstmzdnmxckjmztyymzmzzmsxhhdczjemxxkljstlwlsqlyjzllzjssdppmhnlzjczyhmxxhgzcjmdhxtkgrmxfwmcgmwkdtksxqmmmfzzydkmsclcmpcgmhspxqpzdsslcxkyxtwlwjyahzjgzqmcsnxyymmpmlkjxmhlmlqmxctkzmjqyszjsyszhsyjzjcdajzybsdqjzgwzqqxfkdmsdjlfwehkzqkjpeypzyszcdwyjffmzzylttdzzefmzlbnpplplpepszalltylkckqzkgenqlwagyxydpxlhsxqqwqcqxqclhyxxmlyccwlymqyskgchlcjnszkpyzkcqzqljpdmdzhlasxlbydwqlwdnbqcryddztjybkbwszdxdtnpjdtctqdfxqqmgnxeclttbkpwslctyqlpwyzzklpygzcqqpllkccylpqmzczqcljslqzdjxlddhpzqdljjxzqdxyzqkzljcyqdyjppypqykjyrmpcbymcxkllzllfqpylllmbsglcysslrsysqtmxyxzqzfdzuysyztffmzzsmzqhzssccmlyxwtpzgxzjgzgsjsgkddhtqggzllbjdzlcbchyxyzhzfywxyzymsdbzzyjgtsmtfxqyxqstdgslnxdlryzzlryylxqhtxsrtzngzxbnqqzfmykmzjbzymkbpnlyzpblmcnqyzzzsjzhjctzkhyzzjrdyzhnpxglfztlkgjtctssyllgzrzbbqzzklpklczyssuyxbjfpnjzzxcdwxzyjxzzdjjkggrsrjkmsmzjlsjywqskyhqjsxpjzzzlsnshrnypztwchklpsrzlzxyjqxqkysjycztlqzybbybwzpqdwwyzcytjcjxckcwdkkzxsgkdzxwwyyjqyytcytdllxwkczkklcclzcqqdzlqlcsfqchqhsfsmqzzlnbjjzbsjhtszdysjqjpdlzcdcwjkjzzlpycgmzwdjjbsjqzsyzyhhxjpbjydssxdzncglqmbtsfsbpdzdlznfgfjgfsmpxjqlmblgqcyyxbqkdjjqyrfkztjdhczklbsdzcfjtplljgxhyxzcsszzxstjygkgckgyoqxjplzpbpgtgyjzghzqzzlbjlsqfzgkqqjzgyczbzqtldxrjxbsxxpzxhyzyclwdxjjhxmfdzpfzhqhqmqgkslyhtycgfrzgnqxclpdlbzcsczqlljblhbzcypzzppdymzzsgyhckcpzjgsljlnscdsldlxbmstlddfjmkdjdhzlzxlszqpqpgjllybdszgqlbzlslkyyhzttntjyqtzzpszqztlljtyyllqllqyzqlbdzlslyyzymdfszsnhlxznczqzpbwskrfbsyzmthblgjpmczzlstlxshtcsyzlzblfeqhlxflcjlyljqcbzlzjhhsstbrmhxzhjzclxfnbgxgtqjcztmsfzkjmssnxljkbhsjxntnlzdntlmsjxgzjyjczxyjyjwrwwqnztnfjszpzshzjfyrdjsfszjzbjfzqzzhzlxfysbzqlzsgyftzdcszxzjbqmszkjrhyjzckmjkhchgtxkxqglxpxfxtrtylxjxhdtsjxhjzjxzwzlcqsbtxwxgxtxxhxftsdkfjhzyjfjxrzsdllltqsqqzqwzxsyqtwgwbzcgzllyzbclmqqtzhzxzxljfrmyzflxysqxxjkxrmqdzdmmyybsqbhgzmwfwxgmxlzpyytgzyccdxyzxywgsyjyznbhpzjsqsyxsxrtfyzgrhztxszzthcbfclsyxzlzqmzlmplmxzjxsflbyzmyqhxjsxrxsqzzzsslyfrczjrcrxhhzxqydyhxsjjhzcxzbtynsysxjbqlpxzqpymlxzkyxlxcjlcysxxzzlxdllljjyhzxgyjwkjrwyhcpsgnrzlfzwfzznsxgxflzsxzzzbfcsyjdbrjkrdhhgxjljjtgxjxxstjtjxlyxqfcsgswmsbctlqzzwlzzkxjmltmjyhsddbxgzhdlbmyjfrzfsgclyjbpmlysmsxlszjqqhjzfxgfqfqbpxzgyyqxgztcqwyltlgwsgwhrlfsfgzjmgmgbgtjfsyzzgzyzaflsspmlpflcwbjzcljjmzlpjjlymqdmyyyfbgygyzmlyzdxqyxrqqqhsyyyqxyljtyxfsfsllgnqcyhycwfhcccfxpylypllzyxxxxxkqhhxshjzcfzsczjxcpzwhhhhhapylqalpqafyhxdylukmzqgggddesrnnzltzgchyppysqjjhclljtolnjpzljlhymheydydsqycddhgzundzclzyzllzntnyzgslhslpjjbdgwxpcdutjcklkclwkllcasstkzzdnqnttlyyzssysszzryljqkcqdhhcrxrzydgrgcwcgzqfffppjfzynakrgywyqpqxxfkjtszzxswzddfbbxtbgtzkznpzzpzxzpjszbmqhkcyxyldkljnypkyghgdzjxxeahpnzkztzcmxcxmmjxnkszqnmnlwbwwxjkyhcpstmcsqtzjyxtpctpdtnnpglllzsjlspblplqhdtnjnlyyrszffjfqwdphzdwmrzcclodaxnssnyzrestyjwjyjdbcfxnmwttbylwstszgybljpxglboclhpcbjltmxzljylzxcltpnclckxtpzjswcyxsfyszdkntlbyjcyjllstgqcbxryzxbxklylhzlqzlnzcxwjzljzjncjhxmnzzgjzzxtzjxycyycxxjyyxjjxsssjstssttppgqtcsxwzdcsyfptfbfhfbblzjclzzdbxgcxlqpxkfzflsyltuwbmqjhszbmddbcysccldxycddqlyjjwmqllcsgljjsyfpyyccyltjantjjpwycmmgqyysxdxqmzhszxpftwwzqswqrfkjlzjqqyfbrxjhhfwjjzyqazmyfrhcyybyqwlpexcczstyrlttdmqlykmbbgmyyjprkznpbsxyxbhyzdjdnghpmfsgmwfzmfqmmbcmzzcjjlcnuxyqlmlrygqzcyxzlwjgcjcggmcjnfyzzjhycprrcmtzqzxhfqgtjxccjeaqcrjyhplqlszdjrbcqhqdyrhylyxjsymhzydwldfryhbpydtsscnwbxglpzmlzztqsscpjmxxycsjytycghycjwyrxxlfemwjnmkllswtxhyyyncmmcwjdqdjzglljwjrkhpzggflccsczmcbltbhbqjxqdspdjzzgkglfqywbzyzjltstdhqhctcbchflqmpwdshyytqwcnzzjtlbymbpdyyyxsqkxwyyflxxncwcxypmaelykkjmzzzbrxyyqjfljpfhhhytzzxsgqqmhspgdzqwbwpjhzjdyscqwzktxxsqlzyymysdzgrxckkujlwpysyscsyzlrmlqsyljxbcxtlwdqzpcycykpppnsxfyzjjrcemhszmsxlxglrwgcstlrsxbzgbzgztcplujlslylymtxmtzpalzxpxjtjwtcyyzlblxbzlqmylxpghdslssdmxmbdzzsxwhamlczcpjmcnhjysnsygchskqmzzqdllkablwjxsfmocdxjrrlyqzkjmybyqlyhetfjzfrfksryxfjtwdsxxsysqjyslyxwjhsnlxyyxhbhawhhjzxwmyljcsslkydztxbzsyfdxgxzjkhsxxybssxdpynzwrptqzczenygcxqfjykjbzmljcmqqxuoxslyxxlylljdzbtymhpfsttqqwlhokyblzzalzxqlhzwrrqhlstmypyxjjxmqsjfnbxyxyjxxyqylthylqyfmlkljtmllhszwkzhljmlhljkljstlqxylmbhhlnlzxqjhxcfxxlhyhjjgbyzzkbxscqdjqdsujzyyhzhhmgsxcsymxfebcqwwrbpyyjqtyzcyqyqqzyhmwffhgzfrjfcdpxntqyzpdykhjlfrzxppxzdbbgzqstlgdgylcqmlchhmfywlzyxkjlypqhsywmqqgqzmlzjnsqxjqsyjycbehsxfszpxzwfllbcyyjdytdthwzsfjmqqyjlmqxxlldttkhhybfpwtyysqqwnqwlgwdebzwcmygculkjxtmxmyjsxhybrwfymwfrxyqmxysztzztfykmldhqdxwyynlcryjblpsxcxywlsprrjwxhqyphtydnxhhmmywytzcsqmtssccdalwztcpqpyjllqzyjswxmzzmmylmxclmxczmxmzsqtzppqqblpgxqzhfljjhytjsrxwzxsccdlxtyjdcqjxslqyclzxlzzxmxqrjmhrhzjbhmfljlmlclqnldxzlllpypsyjysxcqqdcmqjzzxhnpnxzmekmxhykyqlxsxtxjyyhwdcwdzhqyybgybcyscfgpsjnzdyzzjzxrzrqjjymcanyrjtldppyzbstjkxxzypfdwfgzzrpymtngxzqbyxnbufnqkrjqzmjegrzgyclkxzdskknsxkcljspjyyzlqqjybzssqlllkjxtbktylccddblsppfylgydtzjyqggkqttfzxbdktyyhybbfytyybclpdytgdhryrnjsptcsnyjqhklllzslydxxwbcjqspxbpjzjcjdzffxxbrmlazhcsndlbjdszblprztswsbxbcllxxlzdjzsjpylyxxyftfffbhjjxgbyxjpmmmpssjzjmtlyzjxswxtyledqpjmygqzjgdjlqjwjqllsjgjgygmscljjxdtygjqjqjcjzcjgdzzsxqgsjggcxhqxsnqlzzbxhsgzxcxyljxyxyydfqqjhjfxdhctxjyrxysqtjxyefyyssyyjxncyzxfxmsyszxyyschshxzzzgzzzgfjdltylnpzgyjyzyyqzpbxqbdztzczyxxyhhsqxshdhgqhjhgywsztmzmlhyxgebtylzkqwytjzrclekystdbcykqqsayxcjxwwgsbhjyzydhcsjkqcxswxfltynyzpzcczjqtzwjqdzzzqzljjxlsbhpyxxpsxshheztxfptlqyzzxhytxncfzyyhxgnxmywxtzsjpthhgymxmxqzxtsbczyjyxxtyyzypcqlmmszmjzzllzxgxzaajzyxjmzxwdxzsxzdzxleyjjzqbhzwzzzqtzpsxztdsxjjjznyazphxyysrnqdthzhyykyjhdzxzlswclybzyecwcycrylcxnhzydzydyjdfrjjhtrsqtxyxjrjhojynxelxsfsfjzghpzsxzszdzcqzbyyklsgsjhczshdgqgxyzgxchxzjwyqwgyhksseqzzndzfkwysstclzstsymcdhjxxyweyxczaydmpxmdsxybsqmjmzjmtzqlpjyqzcgqhxjhhlxxhlhdldjqcldwbsxfzzyyschtytyybhecxhykgjpxhhyzjfxhwhbdzfyzbcapnpgnydmsxhmmmmamynbyjtmpxyymcthjbzyfcgtyhwphftwzzezsbzegpfmtskftycmhfllhgpzjxzjgzjyxzsbbqsczzlzccstpgxmjsftcczjzdjxcybzlfcjsyzfgszlybcwzzbyzdzypswyjzxzbdsyuxlzzbzfygczxbzhzftpbgzgejbstgkdmfhyzzjhzllzzgjqzlsfdjsscbzgpdlfzfzszyzyzsygcxsnxxchczxtzzljfzgqsqyxzjqdccztqcdxzjyqjqchxztdlgscxzsyqjqtzwlqdqztqchqqjzyezzzpbwkdjfcjpztypqyqttynlmbdktjzpqzqzzfpzsbnjlgyjdxjdzzkzgqkxdlpzjtcjdqbxdjqjstcknxbxzmslyjcqmtjqwwcjqnjnlllhjcwqtbzqydzczpzzdzyddcyzzzccjttjfzdprrtztjdcqtqzdtjnplzbcllctzsxkjzqzpzlbzrbtjdcxfczdbccjjltqqpldcgzdbbzjcqdcjwynllzyzccdwllxwzlxrxntqqczxkqlsgdfqtddglrlajjtkuymkqlltzytdyyczgjwyxdxfrskstqtenqmrkqzhhqkdldazfkypbggpzrebzzykzzspegjxgykqzzzslysyyyzwfqzylzzlzhwchkypqgnpgblplrrjyxccsyyhsfzfybzyytgzxylxczwxxzjzblfflgskhyjzeyjhlpllllczgxdrzelrhgklzzyhzlyqszzjzqljzflnbhgwlczcfjyspyxzlzlxgccpzbllcybbbbubbcbpcrnnzczyrbfsrldcgqyyqxygmqzwtzytyjxyfwtehzzjywlccntzyjjzdedpzdztsyqjhdymbjnyjzlxtsstphndjxxbyxqtzqddtjtdyytgwscszqflshlglbczphdlyzjyckwtytylbnytsdsycctyszyyebhexhqdtwnygyclxtszystqmygzazccszzdslzclzrqxyyeljsbymxsxztembbllyyllytdqyshymrqwkfkbfxnxsbychxbwjyhtqbpbsbwdzylkgzskyhxqzjxhxjxgnljkzlyycdxlfyfghljgjybxqlybxqpqgztzplncypxdjyqydymrbesjyyhkxxstmxrczzywxyqybmcllyzhqyzwqxdbxbzwzmslpdmyskfmzklzcyqyczlqxfzzydqzpzygyjyzmzxdzfyfyttqtzhgspczmlccytzxjcytjmkslpzhysnzllytpzctzzcktxdhxxtqcyfksmqccyyazhtjpcylzlyjbjxtpnyljyynrxsylmmnxjsmybcsysylzylxjjqyldzlpqbfzzblfndxqkczfywhgqmrdsxycytxnqqjzyypfzxdyzfprxejdgyqbxrcnfyyqpghyjdyzxgrhtkylnwdzntsmpklbthbpyszbztjzszzjtyyxzphsszzbzczptqfzmyflypybbjqxzmxxdjmtsyskkbjzxhjcklpsmkyjzcxtmljyxrzzqslxxqpyzxmkyxxxjcljprmyygadyskqlsndhyzkqxzyztcghztlmlwzybwsyctbhjhjfcwztxwytkzlxqshlyjzjxtmplpycgltbzztlzjcyjgdtclklpllqpjmzpapxyzlkktkdzczzbnzdydyqzjyjgmctxltgxszlmlhbglkfwnwzhdxuhlfmkyslgxdtwwfrjejztzhydxykshwfzcqshktmqqhtzhymjdjskhxzjzbzzxympagqmstpxlsklzynwrtsqlszbpspsgzwyhtlkssswhzzlyytnxjgmjszsufwnlsoztxgxlsammlbwldszylakqcqctmycfjbslxclzzclxxksbzqclhjpsqplsxxckslnhpsfqqytxyjzlqldxzqjzdyydjnzptuzdskjfsljhylzsqzlbtxydgtqfdbyazxdzhzjnhhqbyknxjjqczmlljzkspldyclbblxklelxjlbqycxjxgcnlcqplzlzyjtzljgyzdzpltqcsxfdmnycxgbtjdcznbgbqyqjwgkfhtnpyqzqgbkpbbyzmtjdytblsqmpsxtbnpdxklemyycjynzctldykzzxddxhqshdgmzsjycctayrzlpyltlkxslzcggexclfxlkjrtlqjaqzncmbydkkcxglczjzxjhptdjjmzqykqsecqzdshhadmlzfmmzbgntjnnlgbyjbrbtmlbyjdzxlcjlpldlpcqdhlxzlycblcxzzjadjlnzmmsssmybhbsqkbhrsxxjmxsdznzpxlgbrhwggfcxgmsklltsjyycqltskywyyhywxbxqywpywykqlsqptntkhqcwdqktwpxxhcpthtwumssyhbwcrwxhjmkmzngwtmlkfghkjylsyycxwhyeclqhkqhttqkhfzldxqwyzyydesbpkyrzpjfyyzjceqdzzdlatzbbfjllcxdlmjssxegygsjqxcwbxsszpdyzcxdnyxppzydlyjczpltxlsxyzyrxcyyydylwwnzsahjsyqyhgywwaxtjzdaxysrltdpssyyfnejdxyzhlxlllzqzsjnyqyqqxyjghzgzcyjchzlycdshwshjzyjxcllnxzjjyyxnfxmwfpylcyllabwddhwdxjmcxztzpmlqzhsfhzynztlldywlslxhymmylmbwwkyxyadtxylldjpybpwuxjmwmllsafdllyflbhhhbqqltzjcqjldjtffkmmmbythygdcqrddwrqjxnbysnwzdbyytbjhpybyttjxaahgqdqtmystqxkbtzpkjlzrbeqqssmjjbdjotgtbxpgbktlhqxjjjcthxqdwjlwrfwqgwshckryswgftgygbxsdwdwrfhwytjjxxxjyzyslpyyypayxhydqkxshxyxgskqhywfdddpplcjlqqeewxksyykdypltjthkjltcyyhhjttpltzzcdlthqkzxqysteeywyyzyxxyysttjkllpzmcyhqgxyhsrmbxpllnqydqhxsxxwgdqbshyllpjjjthyjkyppthyyktyezyenmdshlcrpqfdgfxzpsftljxxjbswyysksflxlpplbbblbsfxfyzbsjssylpbbffffsscjdstzsxzryysyffsyzyzbjtbctsbsdhrtjjbytcxyjeylxcbnebjdsyxykgsjzbxbytfzwgenyhhthzhhxfwgcstbgxklsxywmtmbyxjstzscdyqrcytwxzfhmymcxlznsdjtttxrycfyjsbsdyerxjljxbbdeynjghxgckgscymblxjmsznskgxfbnbpthfjaafxyxfpxmypqdtzcxzzpxrsywzdlybbktyqpqjpzypzjznjpzjlzzfysbttslmptzrtdxqsjehbzylzdhljsqmlhtxtjecxslzzspktlzkqqyfsygywpcpqfhqhytqxzkrsgttsqczlptxcdyyzxsqzslxlzmycpcqbzyxhbsxlzdltcdxtylzjyyzpzyzltxjsjxhlpmytxcqrblzssfjzztnjytxmyjhlhpplcyxqjqqkzzscpzkswalqsblcczjsxgwwwygyktjbbztdkhxhkgtgpbkqyslpxpjckbmllxdzstbklggqkqlsbkktfxrmdkbftpzfrtbbrferqgxyjpzsstlbztpszqzsjdhljqlzbpmsmmsxlqqnhknblrddnxxdhddjcyygylxgzlxsygmqqgkhbpmxyxlytqwlwgcpbmqxcyzydrjbhtdjyhqshtmjsbyplwhlzffnypmhxxhpltbqpfbjwqdbygpnztpfzjgsddtqshzeawzzylltyybwjkxxghlfkxdjtmszsqynzggswqsphtlsskmclzxyszqzxncjdqgzdlfnykljcjllzlmzznhydsshthzzlzzbbhqzwwycrzhlyqqjbeyfxxxwhsrxwqhwpslmsskzttygyqqwrslalhmjtqjsmxqbjjzjxzyzkxbyqxbjxshztsfjlxmxzxfghkzszggylclsarjyhslllmzxelglxydjytlfbhbpnlyzfbbhptgjkwetzhkjjxzxxglljlstgshjjyqlqzfkcgnndjsszfdbctwwseqfhqjbsaqtgypqlbxbmmywxgslzhglzgqyflzbyfzjfrysfmbyzhqgfwzsyfyjjphzbyyzffwodgrlmftwlbzgycqxcdjygzyyyytytydwegazyhxjlzyyhlrmgrxxzclhneljjtjtpwjybjjbxjjtjteekhwsljplpsfyzpqqbdlqjjtyyqlyzkdksqjyyqzldqtgjqyzjsucmryqthtejmfctyhypkmhyzwjdqfhyyxwshctxrljhqxhccyyyjltkttytmxgtcjtzayyoczlylbszywjytsjyhbyshfjlygjxxtmzyyltxxypzlxyjzyzyypnhmymdyylblhlsyyqqllnjjymsoyqbzgdlyxylcqyxtszegxhzglhwbljheyxtwqmakbpqcgyshhegqcmwyywljyjhyyzlljjylhzyhmgsljljxcjjyclycjpcpzjzjmmylcqlnqljqjsxyjmlszljqlycmmhcfmmfpqqmfylqmcffqmmmmhmznfhhjgtthhkhslnchhyqdxtmmqdcyzyxyqmyqyltdcyyyzazzcymzydlzfffmmycqzwzzmabtbyztdmnzzggdftypcgqyttssffwfdtzqssystwxjhxytsxxylbyqhwwkxhzxwznnzzjzjjqjccchyyxbzxzcyztllcqxynjycyycynzzqyyyewyczdcjycchyjlbtzyycqwmpwpymlgkdldlgkqqbgychjxy';
    //如果不在汉字处理范围之内,返回原字符
    if(uni > 40869 || uni < 19968)
        return ch; 
    return strChineseFirstPY.charAt(uni-19968);
}

//去除字符串的前后空白
String.prototype.trim = function(){
      return this.replace(/(^\s*)|(\s*$)/g,"");
}
//判断字符串是否全为数字
String.prototype.IsNum = function(){
    var reg = /^\d+$/g;
    return reg.test(this);
}
//Open Editer Window
function OpenEditerWindow(Url,WindowName,Width,Height,SetObj)
{
	var ReturnStr = window.open(Url,WindowName,'toolbar=0,location=0,maximize=1,directories=0,status=1,menubar=0,scrollbars=1,resizable=1,top=50,left=50,width='+Width+',height='+Height);
	if (ReturnStr!='')SetObj.value=ReturnStr;
	return ReturnStr;
}

function selectAll(f,mode)
{
	if(mode==true)
	{
	    for(i=0;i<f.length;i++)
	    {
		    if(f.elements[i].type=="checkbox")
		    {
			    f.elements[i].checked=true;
		    }
	    }
	}
	else
	{
	    for(i=0;i<f.length;i++)
	    {
		    if(f.elements[i].type=="checkbox")
		    {
			    f.elements[i].checked=false;
		    }
	    }
	}
}

//CSS背景控制
function overColor(Obj)
{
	var elements=Obj.childNodes;
	for(var i=0;i<elements.length;i++)
	{
		elements[i].className="TR_BG"
		Obj.bgColor="";//颜色要改
	}
	
}
function outColor(Obj)
{
	var elements=Obj.childNodes;
	for(var i=0;i<elements.length;i++)
	{
		elements[i].className="TR_BG_list";
		Obj.bgColor="";
	}
}

//CSS背景控制
function useroverColor(Obj)
{
	var elements=Obj.childNodes;
	for(var i=0;i<elements.length;i++)
	{
		elements[i].className="bg_over"
		Obj.bgColor="";//颜色要改
	}
	
}
function useroutColor(Obj)
{
	var elements=Obj.childNodes;
	for(var i=0;i<elements.length;i++)
	{
		elements[i].className="bg_out";
		Obj.bgColor="";
	}
}


function CheckNumber(Obj,DescriptionStr)
{
	if (Obj.value!='' && (isNaN(Obj.value) || Obj.value<0))
	{
		alert(DescriptionStr+"应填有效数字！");
		Obj.value="";
		Obj.focus();
	}
}
//菜单效果
		var menuOffX=2;	
		var menuOffY=32;	
		var fo_shadows=new Array();
		var linkset=new Array();
		
		var ie4=document.all&&navigator.userAgent.indexOf("Opera")==-1
		var ns6=document.getElementById&&!document.all
		var ns4=document.layers
		
		function showmenu(e,index,p,paging){
			if (!document.all&&!document.getElementById&&!document.layers)
				return
			which=linkset[index];
			var pSize=25	//每页
			var pNum=Math.floor((which.length-1)/pSize)+1		//页
			
			clearhidemenu()
			ie_clearshadow()
			if (pNum==1){
				which=which.join("")
			}else{
				which=which.slice( (p-1)*pSize, p*pSize )
				which=which.join("")
				which+=""
				if (p==1)
				{
					which+="&nbsp;&nbsp;&nbsp;&nbsp;<font face=webdings color=gray>7</font>"
				}else{
					which+="&nbsp;&nbsp;&nbsp;&nbsp;<font face=webdings style=cursor:hand onclick=showmenu(event,"+ index +","+ (p-1) +",true) >7</font>"
				}
				if (p==pNum)
				{
					which+="<font face=webdings color=gray>8</font>"
				}else{
					which+="<font face=webdings style=cursor:hand onclick=showmenu(event,"+ index +","+ (p+1) +",true) >8</font>"
				}
				which+=""
			}
			
			menuobj=ie4? document.all.popmenu : ns6? document.getElementById("popmenu") : ns4? document.popmenu : ""
			menuobj.thestyle=(ie4||ns6)? menuobj.style : menuobj
			
			if (ie4||ns6)
				menuobj.innerHTML=which
				
			else{
				menuobj.document.write('<layer name=gui bgColor=#E6E6E6 width=165 onmouseover="clearhidemenu()" onmouseout="hidemenu()">'+which+'</layer>')
				menuobj.document.close()
			}
			menuobj.contentwidth=(ie4||ns6)? menuobj.offsetWidth : menuobj.document.gui.document.width
			menuobj.contentheight=(ie4||ns6)? menuobj.offsetHeight : menuobj.document.gui.document.height
			
			eventX=ie4? event.clientX : ns6? e.clientX : e.x
			eventY=ie4? event.clientY : ns6? e.clientY : e.y
			
			var rightedge=ie4? document.body.clientWidth-eventX : window.innerWidth-eventX
			var bottomedge=ie4? document.body.clientHeight-eventY : window.innerHeight-eventY
			
			
			if (!paging)
			{	
				if (rightedge<menuobj.contentwidth)
					menuobj.thestyle.left=ie4? document.body.scrollLeft+eventX-menuobj.contentwidth+menuOffX : ns6? window.pageXOffset+eventX-menuobj.contentwidth : eventX-menuobj.contentwidth
				else
					menuobj.thestyle.left=ie4? ie_x(event.srcElement)+menuOffX : ns6? window.pageXOffset+eventX : eventX
				
				if (bottomedge<menuobj.contentheight)
					menuobj.thestyle.top=ie4? document.body.scrollTop+eventY-menuobj.contentheight-event.offsetY+menuOffY : ns6? window.pageYOffset+eventY-menuobj.contentheight : eventY-menuobj.contentheight
				else
					menuobj.thestyle.top=ie4? ie_y(event.srcElement)+menuOffY : ns6? window.pageYOffset+eventY : eventY
			}
				
			menuobj.thestyle.visibility="visible"
			ie_dropshadow(menuobj,"#DCDCDC",3)
			return false
		}
		function ie_x(e){  
			var l=e.offsetLeft;  
			while(e=e.offsetParent){  
				l+=e.offsetLeft;  
			}  
			return l;  
		}  
		
		
		function ie_y(e){  
			var t=e.offsetTop;  
			while(e=e.offsetParent){  
				t+=e.offsetTop;  
			}  
			return t;  
		}  
		
		function ie_dropshadow(el, color, size)
		{
			var i;
			for (i=size; i>0; i--)
			{
				var rect = document.createElement('div');
				var rs = rect.style
				rs.position = 'absolute';
				rs.left = (el.style.posLeft + i) + 'px';
				rs.top = (el.style.posTop + i) + 'px';
				rs.width = el.offsetWidth + 'px';
				rs.height = el.offsetHeight + 'px';
				rs.zIndex = el.style.zIndex - i;
				rs.backgroundColor = color;
				var opacity = 1 - i / (i + 1);
				rs.filter = 'alpha(opacity=' + (100 * opacity) + ')';
				el.insertAdjacentElement('afterEnd', rect);		
				fo_shadows[fo_shadows.length] = rect;
			}
		}
		function ie_clearshadow()
		{
			for(var i=0;i<fo_shadows.length;i++)
			{
				if (fo_shadows[i])
					fo_shadows[i].style.display="none"
			}
			fo_shadows=new Array();
		}
		
		
		function contains_ns6(a, b) {
			while (b.parentNode)
				if ((b = b.parentNode) == a)
					return true;
			return false;
		}
		
		function hidemenu(){
			if (window.menuobj)
				menuobj.thestyle.visibility=(ie4||ns6)? "hidden" : "hide"
			ie_clearshadow()
		}
		
		function dynamichide(e){
			if (ie4&&!menuobj.contains(e.toElement))
				hidemenu()
			else if (ns6&&e.currentTarget!= e.relatedTarget&& !contains_ns6(e.currentTarget, e.relatedTarget))
				hidemenu()
		}
		
		function delayhidemenu(){
			if (ie4||ns6||ns4)
				delayhide=setTimeout("hidemenu()",800)
		}
		
		function clearhidemenu(){
			if (window.delayhide)
				clearTimeout(delayhide)
		}
		
		function highlightmenu(e,state){
			if (document.all)
				source_el=event.srcElement
			else if (document.getElementById)
				source_el=e.target
			if (source_el.className=="menuitems"){
				source_el.id=(state=="on")? "mouseoverstyle" : ""
			}
			else{
				while(source_el.id!="popmenu"){
					source_el=document.getElementById? source_el.parentNode : source_el.parentElement
					if (source_el.className=="menuitems"){
						source_el.id=(state=="on")? "mouseoverstyle" : ""
					}
				}
			}
		}
				

		function imgzoom(img,maxsize){
			var a=new Image();
			a.src=img.src
			if(a.width > maxsize * 4)
			{
				img.style.width=maxsize;
			}
			else if(a.width >= maxsize)
			{
				img.style.width=Math.round(a.width * Math.floor(4 * maxsize / a.width) / 4);
			}
			return false;
		}
		function zoom_img(e, o)
		{
		var zoom = parseInt(o.style.zoom, 10) || 100;
		zoom += event.wheelDelta / 12;
		if (zoom > 0) o.style.zoom = zoom + '%';
		return false;
		}  




position = function(x,y)
{
    this.x = x;
    this.y = y;
}

getPosition = function(oElement)
{
    var objParent = oElement
    var oPosition = new position(0,0);
    while (objParent.tagName != "BODY")
    {
        oPosition.x += objParent.offsetLeft;
        oPosition.y += objParent.offsetTop;
        objParent = objParent.offsetParent;
    }
    return oPosition;
} 

function showDiv(obj,content)

{
    var pos = getPosition(obj)
    var objDiv = document.createElement("div");
    objDiv.className="lionrong";//For IE
    objDiv.style.position = "absolute";
	var tempheight=pos.y;
	var tempwidth1,tempheight1;
	var windowwidth=document.body.clientWidth;
	
	var isIE5 = (navigator.appVersion.indexOf("MSIE 5")>0) || (navigator.appVersion.indexOf("MSIE")>0 && parseInt(navigator.appVersion)> 4);
	var isIE55 = (navigator.appVersion.indexOf("MSIE 5.5")>0);
	var isIE6 = (navigator.appVersion.indexOf("MSIE 6")>0);
	var isIE7 = (navigator.appVersion.indexOf("MSIE 7")>0);

	if(isIE5||isIE55||isIE6||isIE7){var tempwidth=pos.x+305;}else{var tempwidth=pos.x+312;}
	objDiv.style.width = "300px";
    objDiv.innerHTML = content;
	if (tempwidth>windowwidth)
	{
		tempwidth1=tempwidth-windowwidth
		objDiv.style.left = (pos.x-tempwidth1) + "px";
	}
	else
	{
		if(isIE5||isIE55||isIE6||isIE7){objDiv.style.left = (pos.x + 10) + "px";}else{objDiv.style.left = (pos.x) + "px";}
	}
	if(isIE5||isIE55||isIE6||isIE7){objDiv.style.top = (pos.y+16) + "px";}else{objDiv.style.top = (pos.y+16) + "px";}

    objDiv.style.display = "";
    document.onclick=function () { if(objDiv.style.display==""){objDiv.style.display="none";} }
    document.body.appendChild(objDiv);
}

function ShowDivPic(obj,Urls,exname,length)
{
    var Url = Urls.replace("\\","/");
    var pos = getPosition(obj)
    var objDiv = document.createElement("div");
    objDiv.className="lionrong";//For IE
    objDiv.id="showpic_id";
    objDiv.style.position = "absolute";
	var tempheight=pos.y;
	var tempwidth1,tempheight1;
	var windowwidth=document.body.clientWidth;
	
	var isIE5 = (navigator.appVersion.indexOf("MSIE 5")>0) || (navigator.appVersion.indexOf("MSIE")>0 && parseInt(navigator.appVersion)> 4);
	var isIE55 = (navigator.appVersion.indexOf("MSIE 5.5")>0);
	var isIE6 = (navigator.appVersion.indexOf("MSIE 6")>0);
	var isIE7 = (navigator.appVersion.indexOf("MSIE 7")>0);
	switch(exname)
	{
	    case ".jpg":case ".gif":case ".bmp":case ".ico":case ".png":case ".jpeg":case ".tif":
	        if(length<12000)
	        {
                if(Url=="")
                {
                    var content = "无图片";
                }
                else
                {
                    var content = "<img src='"+Url+"' border='0' />";
                }
            }
            else
            {
                var content = "<img src='"+Url+"' border='0' width='100px'/>";
            }
            break;
	    case ".swf":
	        if(length<12000)
	        {
            var content = "<object classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\" codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\">";
            content+="<param name=\"movie\" value=\""+Url+"\" />"
            content+="<param name=\"quality\" value=\"high\" />"
            content+="<embed src=\""+Url+"\" quality=\"high\" pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\"></embed>"
            content+="</object>"
            }
            else
            {
            var content = "<object classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\" codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\" width=\"100px\">";
            content+="<param name=\"movie\" value=\""+Url+"\" />"
            content+="<param name=\"quality\" value=\"high\" />"
            content+="<embed src=\""+Url+"\" quality=\"high\" pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\" width=\"100px\"></embed>"
            content+="</object>"
            }
            break;
            break;
	    case ".html":case ".htm":case ".aspx":case ".shtm":case ".shtml":case ".asp":
            var content = "Path:"+Url;
            break;
        default:
            var content = "Path:"+Url;
            break;
	}
	if(isIE5||isIE55||isIE6||isIE7){var tempwidth=pos.x+250;}else{var tempwidth=pos.x+250;}
    objDiv.innerHTML = content;
	if (tempwidth>windowwidth)
	{
		tempwidth1=tempwidth-windowwidth
		objDiv.style.left = (pos.x-tempwidth1) + "px";
	}
	else
	{
		if(isIE5||isIE55||isIE6||isIE7){objDiv.style.left = (pos.x) + "px";}else{objDiv.style.left = (pos.x) + "px";}
	}
	if(isIE5||isIE55||isIE6||isIE7){objDiv.style.top = (pos.y+18) + "px";}else{objDiv.style.top = (pos.y+18) + "px";}

	objDiv.style.left = "250px";
    objDiv.style.top = (pos.y-68) + "px";
    objDiv.style.display = "";
    document.onclick=function () { if(objDiv.style.display==""){objDiv.style.display="none";} }
    document.body.appendChild(objDiv);
}

function hiddDivPic()
{
    var objDiv = document.getElementById("showpic_id");
    if (objDiv!=null&&objDiv!="undefined")
    {
       document.body.removeChild(objDiv);
    }
}
function closediv(objDiv)
{
   objDiv.parentNode.removeChild(objDiv);
}

function showfDiv(obj,content,width)

{
    var pos = getPosition(obj);
    var objDiv = document.getElementById("s_id");
    if (objDiv==null)
    {
        objDiv = document.createElement("div");
        objDiv.id="s_id";
    }
    objDiv.className="selectStyle";
    objDiv.style.position = "absolute";
	var tempheight=pos.y;
	var tempwidth1,tempheight1;
	var windowwidth=document.body.clientWidth;
	
	var isIE5 = (navigator.appVersion.indexOf("MSIE 5")>0) || (navigator.appVersion.indexOf("MSIE")>0 && parseInt(navigator.appVersion)> 4);
	var isIE55 = (navigator.appVersion.indexOf("MSIE 5.5")>0);
	var isIE6 = (navigator.appVersion.indexOf("MSIE 6")>0);
	var isIE7 = (navigator.appVersion.indexOf("MSIE 7")>0);

	if(isIE5||isIE55||isIE6||isIE7){var tempwidth=pos.x+305;}else{var tempwidth=pos.x+312;}
	objDiv.style.width = width+"px";
    objDiv.innerHTML = content;
	if (tempwidth>windowwidth)
	{
		tempwidth1=tempwidth-windowwidth
		objDiv.style.left = (pos.x-tempwidth1) + "px";
	}
	else
	{
		if(isIE5||isIE55||isIE6||isIE7){objDiv.style.left = (pos.x) + "px";}else{objDiv.style.left = (pos.x) + "px";}
	}
	if(isIE5||isIE55||isIE6||isIE7){objDiv.style.top = (pos.y+22) + "px";}else{objDiv.style.top = (pos.y+22) + "px";}

    objDiv.style.display = "";
    document.ondblclick=function () { if(objDiv.style.display==""){objDiv.style.display="none";} }
    document.body.appendChild(objDiv);
}

function selectFile(type,obj,height,width)
{
    var ShowObj = obj;
    if(isArray(obj) && obj.length > 1)
        ShowObj = obj[1];
    showfDiv(ShowObj,"loading...",width);
    LastSelectObj = obj;
    
	var  options={  
					   method:'get',  
					   parameters:"heights="+ height,  
					   onComplete:function(transport)
						{  
							var returnvalue=transport.responseText;
							if (returnvalue.indexOf("??")>-1)
								showfDiv(ShowObj,'Error',width);
							else
								var tempstr=returnvalue;
								showfDiv(ShowObj,tempstr,width);
						}  
				   }; 
	var arrtype=type.split("|")[0]
    switch(arrtype)
        {
            case "file":
	            new  Ajax.Request('../../configuration/system/iframe.aspx?FileType=file',options);
	            break;
	        case "pic":
	            new  Ajax.Request('../../configuration/system/iframe.aspx?FileType=pic',options);
	            break;
	        case "picEdit":
	            new  Ajax.Request('../../configuration/system/iframe.aspx?FileType=picEdit',options);
	            break;
	        case "date":
	            new  Ajax.Request('../../configuration/system/iframe.aspx?FileType=date',options);
	            break;
	        case "templet":
	            new  Ajax.Request('../../configuration/system/iframe.aspx?FileType=templet',options);
	            break;
	        case "path":
	            new  Ajax.Request('../../configuration/system/iframe.aspx?FileType='+type,options);
	            break;
	        case "newsclass":
	            new  Ajax.Request('../../configuration/system/iframe.aspx?FileType=newsclass',options);
	            break;
	        case "special":
	            new  Ajax.Request('../../configuration/system/iframe.aspx?FileType=special',options);
	            break;
	        case "newsspecial":
	            new  Ajax.Request('../../configuration/system/iframe.aspx?FileType=newsspecial',options);
	            break;
	        case "user_file":
	            new  Ajax.Request('../../configuration/system/iframe.aspx?FileType=user_file',options);
	            break;
	        case "user_pic":
	            new  Ajax.Request('../../configuration/system/iframe.aspx?FileType=user_pic',options);
	            break;
	        case "rulePram":
	            new  Ajax.Request('../../configuration/system/iframe.aspx?FileType=rulePram',options);
	            break;
	        case "rulesmallPramo":
	            new  Ajax.Request('../../configuration/system/iframe.aspx?FileType=rulesmallPramo',options);
	            break;
	        case "rulesmallPram":
	            new  Ajax.Request('../../configuration/system/iframe.aspx?FileType=rulesmallPram',options);
	            break;
	        case "discuss_file":
	            new  Ajax.Request('../../configuration/system/iframe.aspx?FileType=discuss_file',options);
	            break;
	        case "discuss_pic":
	            new  Ajax.Request('../../configuration/system/iframe.aspx?FileType=discuss_pic',options);
	            break;
	        case "newsLink":
	            new  Ajax.Request('../../configuration/system/iframe.aspx?FileType=newsLink',options);
	            break;
	        case "style":
	            new  Ajax.Request('../../configuration/system/iframe.aspx?FileType=style',options);
	            break;
	        case "Channel":
	            new  Ajax.Request('../../configuration/system/iframe.aspx?FileType=Channel',options);
	            break;
	        case "user_Hpic":
	            new  Ajax.Request('../../configuration/system/iframe.aspx?FileType=user_Hpic',options);
	            break;
	        case "Souce":
	            new  Ajax.Request('../../configuration/system/iframe.aspx?FileType=Souce',options);
	            break;
	        case "Author":
	            new  Ajax.Request('../../configuration/system/iframe.aspx?FileType=Author',options);
	            break;
	        case "Tag":
	            new  Ajax.Request('../../configuration/system/iframe.aspx?FileType=Tag',options);
	            break;
	        case "xml":
	            new  Ajax.Request('../../configuration/system/iframe.aspx?FileType=xml',options);
	            break;
	    }
}

function subselect(type,value)
{
	 var  options={  
					   method:'get',  
					   parameters:"FileType="+ type,  
					   onComplete:function(transport)
						{  
							var returnvalue=transport.responseText;
							if (returnvalue.indexOf("??")>-1)
								showfDiv(obj,'Error');
							else
								var tempstr=returnvalue;
								showfDiv(obj,tempstr);
						}  
				   }; 
}

function Help(HelpID,obj)
{
	 var  options={  
					   method:'get',  
					   parameters:"Type=ShowHelp&HelpID="+HelpID,  
					   onComplete:function(transport)
						{  
							var returnvalue=transport.responseText;
							if (returnvalue.indexOf("??")>-1)
								showDiv(obj,'Error');
							else
								var tempstr=returnvalue;
								showDiv(obj,tempstr);
						}  
				   }; 
	new  Ajax.Request('../../configuration/system/HelpAjax.aspx?no-cache='+Math.random(),options);
}

var theDownedButtonObj=null;
function CheckBTN(theObj,URL)
{
	var ns6 = document.getElementById&&!document.all
 
    if(ns6)
    {
	    if (!theDownedButtonObj) {theDownedButtonObj='button_down';}
	        if (theObj.className!='button')
	        {
		        theObj.className='button';
		        theDownedButtonObj.className='button_down';
		        theDownedButtonObj=theObj;
		        frames["sys_main"].location=URL;
	        }
	}
	else
	{
	    if (!theDownedButtonObj) {theDownedButtonObj=IDC_DownedBUtton;}
	        if (theObj.className!='button')
	        {
		        theObj.className='button';
		        theDownedButtonObj.className='button_down';
		        theDownedButtonObj=theObj;
		        frames["sys_main"].location=URL;
	        }
	}
}

function GetColor(img_val,input_val)
{
	var PaletteLeft,PaletteTop
	var obj = document.getElementById("colorPalette");
	ColorImg = img_val;
	ColorValue = document.getElementById(input_val);	
	if (obj){
		PaletteLeft = getOffsetLeft(ColorImg)
		PaletteTop = (getOffsetTop(ColorImg)-250)
		if (PaletteTop<0)PaletteTop+=ColorImg.offsetHeight+165;
		if (PaletteLeft+260 > parseInt(document.body.clientWidth)) PaletteLeft = parseInt(event.clientX)-280;
		obj.style.left = PaletteLeft + "px";
		obj.style.top = PaletteTop + "px";
		if (obj.style.visibility=="hidden")
		{
			obj.style.visibility="visible";
		}else {
			obj.style.visibility="hidden";
		}
	}
}
function getOffsetLeft(elm) {
	var mOffsetLeft = elm.offsetLeft;
	var mOffsetParent = elm.offsetParent;
	while(mOffsetParent) {
		mOffsetLeft += mOffsetParent.offsetLeft;
		mOffsetParent = mOffsetParent.offsetParent;
	}
	return mOffsetLeft;
}
function getOffsetTop(elm) {
	var mOffsetTop = elm.offsetTop;
	var mOffsetParent = elm.offsetParent;
	while(mOffsetParent){
		mOffsetTop += mOffsetParent.offsetTop;
		mOffsetParent = mOffsetParent.offsetParent;
	}
	return mOffsetTop;
}
function setColor(color)
{
	if(ColorImg.id=="FontColorShow"&&color=="#") color='#000000';
	if(ColorImg.id=="FontBgColorShow"&&color=="#") color='#FFFFFF';
	if (ColorValue){ColorValue.value = color.substr(1);}
	if (ColorImg && color.length>1){
		ColorImg.src=src='../../sysImages/FileIcon/Rect.gif';
		ColorImg.style.backgroundColor = color;
	}else if(color=='#'){ ColorImg.src='../../sysImages/FileIcon/rectNoColor.gif';}
	document.getElementById("colorPalette").style.visibility="hidden";
}


function add_discussManage(sa)
    {
        switch(sa)
        {
            case 0://参数设置
            document.getElementById("addmanage").style.display="";
            document.getElementById("updatemanage").style.display="none";
            break;
            case 1://参数设置
            document.getElementById("addmanage").style.display="none";
            document.getElementById("updatemanage").style.display="";
            break;
         }
     }


function discussManage_list(sa)
    {
        switch(sa)
        {
            case 0://参数设置
            document.getElementById("tlzlist").style.display="";
            document.getElementById("jrlist").style.display="none";
            document.getElementById("cjlist").style.display="none";
            break;
            case 1://参数设置
            document.getElementById("tlzlist").style.display="none";
            document.getElementById("jrlist").style.display="";
            document.getElementById("cjlist").style.display="none";
            break;
            case 2://参数设置
            document.getElementById("tlzlist").style.display="none";
            document.getElementById("jrlist").style.display="none";
            document.getElementById("cjlist").style.display="";
            break;
         }
     }


var LastSelectObj;
    function sFiles(obj)
    {
      document.Templetslist.sUrl.value=obj;
    }

    function ReturnFun(Return_Strs)
    {
        if(isArray(LastSelectObj))
        {
            for(var i=0;i<LastSelectObj.length;i++)
            {
                SetValue(LastSelectObj[i],Return_Strs[i]);
            }
        }
        else
        {
            SetValue(LastSelectObj,Return_Strs);
        }
	    document.getElementById("s_id").style.display="none";
    }
    function SetValue(obj,val)
    {
        if (obj==null || typeof(obj)=="undefined")
	    {
	        alert("选择失败，请重新选择。");
	    }
	    else
	    {
	        if(val == null || typeof(val)=="undefined")
	            val = '';
	        obj.value = val;
	    }	            
    }
    function ReturnTagsFun(Return_Strs)
    {
	    var  s = LastSelectObj.value
	    if (typeof(LastSelectObj)=="undefined" || LastSelectObj==null)
	    {
	        alert("选择失败，请重新选择。");
	    }
	    else
	    {
	        if(s.indexOf(Return_Strs)==-1)
	        {
	            if(s=="")
	            {
	                LastSelectObj.value = Return_Strs;
	            }
	            else
	            {
	                LastSelectObj.value = s + "|" + Return_Strs;
	            }
	        }
	    }
	    document.getElementById("s_id").style.display="none";
	    return;
    }

function setCookie(name,value)
{
  var Days = 1; //此 cookie 将被保存 1 天
  var exp  = new Date();    //new Date("December 31, 9998");
  exp.setTime(exp.getTime() + Days*24*60*60*1000);
  document.cookie = name + "="+ escape(value) +";expires="+ exp.toGMTString();
}

function getCookie(name)
{
  var arr = document.cookie.match(new RegExp("(^| )"+name+"=([^;]*)(;|$)"));
  if(arr != null) return unescape(arr[2]); return null;
}

function delCookie(name)
{
  var exp = new Date();
  exp.setTime(exp.getTime() - 1);
  var cval=getCookie(name);
  if(cval!=null) document.cookie=name +"="+cval+";expires="+exp.toGMTString();
}


function show(type,obj,title,label_width,height)
{
    var label_temp1 = "<div onmousedown=\"drag(event,$('LabelDivid'));\" class=\"titile_bg\" style=\"cursor:move;\">\
    <table style=\"width:100%;\">\
    <tr>\
    <td>\
    <font color=\"white\">" + title + "</font></td>\
    <td style=\"width:20px\">\
    <img src=\"../../sysImages/normal/close.gif\" style=\"cursor:pointer;\" title=\"close\" onclick=\"closediv($('LabelDivid'));\" />\
    </td>\
    </tr>\
    </table>\
    </div>\
    <iframe src=";
    var label_temp2 = " frameborder=\"0\" id=\"select_main\" scrolling=\"yes\" name=\"select_main\" width=\"100%\" height=\""+height+"px\" />";
    var label_temp3 = "";
    switch(type)
    {
        case "List":
            label_temp3 = label_temp1 + "createLabel_List.aspx" + label_temp2;
            break;
        case "simpleList":
            label_temp3 = label_temp1 + "createLabel_simpleList.aspx" + label_temp2;
            break;
        case "Ultimate":
            label_temp3 = label_temp1 + "createLabel_Ultimate.aspx" + label_temp2;
            break;
        case "Routine":
            label_temp3 = label_temp1 + "createLabel_Routine.aspx" + label_temp2;
            break;
        case "Browse":
            label_temp3 = label_temp1 + "createLabel_Browse.aspx" + label_temp2;
            break;
        case "Member":
            label_temp3 = label_temp1 + "createLabel_Member.aspx" + label_temp2;
            break;
        case "Other":
            label_temp3 = label_temp1 + "createLabel_Other.aspx" + label_temp2;
            break;
        case  "adList":
            label_temp3 = label_temp1 + "createLabel_adList.aspx" + label_temp2;
            break;
        case "API":
            label_temp3 = label_temp1 + "createLabel_API.aspx" + label_temp2;
            break;
        case "PageID":
            label_temp3 = label_temp1 + "selectPagestyle.aspx" + label_temp2;
            break;
        case "Label1":
            label_temp3 = label_temp1 + "../Templet/LabelList.aspx?sys=1" + label_temp2;
            break;
        case "Labelm":
            label_temp3 = label_temp1 + "../Templet/LabelListm.aspx" + label_temp2;
            break;
        case "Label":
            label_temp3 = label_temp1 + "../Templet/LabelList.aspx" + label_temp2;
            break;
        case "freeLabel":
            label_temp3 = label_temp1 + "../Templet/freeLabelList.aspx" + label_temp2;
            break;
        case "ChannelLabel":
            label_temp3 = label_temp1 + "../Channel/ChannelLabelList.aspx" + label_temp2;
            break;
        case "sNews":
            label_temp3 = label_temp1 + "../../configuration/system/ShowNews.aspx" + label_temp2;
            break;
    }
    showlabelDiv(obj,label_temp3,label_width);
}

function show_channel(type,obj,title,label_width,height,chid)
{
    var label_temp1 = "<div onmousedown=\"drag(event,$('LabelDivid'));\" class=\"titile_bg\" style=\"cursor:move;\">\
    <table style=\"width:100%;\">\
    <tr>\
    <td>\
    <font color=\"white\">" + title + "</font></td>\
    <td style=\"width:20px\">\
    <img src=\"../../sysImages/normal/close.gif\" style=\"cursor:pointer;\" title=\"close\" onclick=\"closediv($('LabelDivid'));\" />\
    </td>\
    </tr>\
    </table>\
    </div>\
    <iframe src=";
    var label_temp2 = " frameborder=\"0\" id=\"select_main\" scrolling=\"yes\" name=\"select_main\" width=\"100%\" height=\""+height+"px\" />";
    var label_temp3 = "";
    switch(type)
    {
        case "ch_List":
            label_temp3 = label_temp1 + "../Channel/CreatLabel/ch_List.aspx?ChID="+chid+"" + label_temp2;
            break;
        case "ch_elist":
            label_temp3 = label_temp1 + "../Channel/CreatLabel/ch_elist.aspx?ChID="+chid+"" + label_temp2;
            break;
        case "ch_read":
            label_temp3 = label_temp1 + "../Channel/CreatLabel/ch_read.aspx?ChID="+chid+"" + label_temp2;
            break;
        case "ch_top":
            label_temp3 = label_temp1 + "../Channel/CreatLabel/ch_top.aspx?ChID="+chid+"" + label_temp2;
            break;
        case "ch_user":
            label_temp3 = label_temp1 + "../Channel/CreatLabel/ch_user.aspx?ChID="+chid+"" + label_temp2;
            break;
        case "ch_other":
            label_temp3 = label_temp1 + "../Channel/CreatLabel/ch_other.aspx?ChID="+chid+"" + label_temp2;
            break;
        case "PageID":
            label_temp3 = label_temp1 + "../../Label/selectPagestyle.aspx" + label_temp2;
            break;
    }
    showlabelDiv(obj,label_temp3,label_width);
}


function showlabelDiv(obj,content,width)
{
    var pos = getPosition(obj);
    var objDiv = document.getElementById("LabelDivid");
    if (objDiv==null)
    {
        objDiv = document.createElement("div");
        objDiv.id="LabelDivid";
    }
    objDiv.className="selectStyle";//For IE
    objDiv.style.position = "absolute";
	var tempheight=pos.y;
	var tempwidth1,tempheight1;
	var windowwidth=document.body.clientWidth;
	
	var isIE5 = (navigator.appVersion.indexOf("MSIE 5")>0) || (navigator.appVersion.indexOf("MSIE")>0 && parseInt(navigator.appVersion)> 4);
	var isIE55 = (navigator.appVersion.indexOf("MSIE 5.5")>0);
	var isIE6 = (navigator.appVersion.indexOf("MSIE 6")>0);
	var isIE7 = (navigator.appVersion.indexOf("MSIE 7")>0);

	if(isIE5||isIE55||isIE6||isIE7){var tempwidth=pos.x+305;}else{var tempwidth=pos.x+312;}
	objDiv.style.width = width+"px";
    objDiv.innerHTML = content;
	if (tempwidth>windowwidth)
	{
		tempwidth1=tempwidth-windowwidth
		objDiv.style.left = (pos.x-tempwidth1) + "px";
	}
	else
	{
		if(isIE5||isIE55||isIE6||isIE7){objDiv.style.left = (pos.x) + "px";}else{objDiv.style.left = (pos.x) + "px";}
	}
	if(isIE5||isIE55||isIE6||isIE7){objDiv.style.top = (pos.y+22) + "px";}else{objDiv.style.top = (pos.y+22) + "px";}

    objDiv.style.display = "";
    document.ondblclick=function () { if(objDiv.style.display==""){objDiv.style.display="none";} }
    document.body.appendChild(objDiv);
}

function ReturnLabelValue(value)
{
    IDContentTextBox.insertHTML(value);
    document.getElementById("LabelDivid").style.display="none";
    return;
}

function ReturnLabelValueText(value)
{
    try
    {
//        //IDContent.insertHTML(value)
//        IDContentTextBox.insertHTML(value);
        if(value!="")
        {
            var oEditor = FCKeditorAPI.GetInstance("FileContent");
            if (oEditor.EditMode==FCK_EDITMODE_WYSIWYG)
            {
               oEditor.InsertHtml(value);
            }else
            {
            return false;
            }
        }
    }
    catch(e)
    {
        insert(value);
    }
    finally
    {
        document.getElementById("LabelDivid").style.display="none";
        return;
    }
}

function ReturnNewsValueText(value)
{
    try
    {
        SubNewsContent.insertHTML(value);
    }
    catch(e)
    {
        insertNews(value);
    }
    finally
    {
        document.getElementById("LabelDivid").style.display="none";
        return;
    }
}

function insert(returnValue_lable)
{
	obj=document.getElementById("FileContent");
	obj.focus();
	if(document.selection==null)
	{
		var iStart = obj.selectionStart
		var iEnd = obj.selectionEnd;
		obj.value = obj.value.substring(0, iEnd) +returnValue_lable+ obj.value.substring(iEnd, obj.value.length);
	}else
	{
		var range = document.selection.createRange();
		range.text=returnValue_lable;
	}
}


function insertNews(returnValue_lable)
{
	obj=document.getElementById("SubNewsContent");
	obj.focus();
	if(document.selection==null)
	{
		var iStart = obj.selectionStart
		var iEnd = obj.selectionEnd;
		obj.value = obj.value.substring(0, iEnd) +returnValue_lable+ obj.value.substring(iEnd, obj.value.length);
	}else
	{
		var range = document.selection.createRange();
		range.text=returnValue_lable;
	}
}

function ReturnPageInfoValue(value)
{
    document.ListLabel.PageID.value=value;
    document.getElementById("LabelDivid").style.display="none";
    return;
}


    drag=function (a,o){
	    var d=document;if(!a)a=window.event;
		if(!a.pageX)a.pageX=a.clientX;
		if(!a.pageY)a.pageY=a.clientY;
	    var x=a.pageX,y=a.pageY;
	    if(o.setCapture)
		    o.setCapture();
	    else if(window.captureEvents)
		    window.captureEvents(Event.MOUSEMOVE|Event.MOUSEUP);
	    var backData = {x : o.style.top, y : o.style.left};
	    d.onmousemove=function(a){
		    if(!a)a=window.event;
		    if(!a.pageX)a.pageX=a.clientX;
		    if(!a.pageY)a.pageY=a.clientY;
		    var tx=a.pageX-x+parseInt(o.style.left),ty=a.pageY-y+parseInt(o.style.top);
		    o.style.left=tx+"px";
		    o.style.top=ty+"px";
			x=a.pageX;
			y=a.pageY;
	    };

	    d.onmouseup=function(a){
		    if(!a)a=window.event;
		    if(o.releaseCapture)
			    o.releaseCapture();
		    else if(window.captureEvents)
			    window.captureEvents(Event.MOUSEMOVE|Event.MOUSEUP);
		    d.onmousemove=null;
		    d.onmouseup=null;
		    if(!a.pageX)a.pageX=a.clientX;
		    if(!a.pageY)a.pageY=a.clientY;
		    if(!document.body.pageWidth)document.body.pageWidth=document.body.clientWidth;
		    if(!document.body.pageHeight)document.body.pageHeight=document.body.clientHeight;
		    if(a.pageX < 1 || a.pageY < 1 || a.pageX > document.body.pageWidth || a.pageY > document.body.pageHeight){
			    o.style.left = backData.y;
			    o.style.top = backData.x;
		    }
	    };
    }
 



function getHelpCode(code)
{
    var ie4=document.all&&navigator.userAgent.indexOf("Opera")==-1
    var ns6=document.getElementById&&!document.all
    if (ie4)
    {
        var clipBoardContent=code;
        window.clipboardData.setData("Text",clipBoardContent);
        alert("帮助代码已经复制。代码："+code+"");
    }
    else
    {
        alert("FireFox浏览器用户请直接复制代码!");
    }
}

var intLeft = 2; 
function returnPage(Url) 
{
    if (0 == intLeft)
    {
//        window.location.href=Url;
    top.location.href =Url;
    }
    else 
    {
        intLeft -= 1;
        document.all.countdown.innerText = intLeft + " ";
        setTimeout("returnPage('"+Url+"')", 1000);
    }
}
function backlogin(Url)
{
 top.location.href =Url;
}
//判断是否数组
function isArray(obj)
{   
  if(obj.constructor == window.Array)   
    return true;
  else   
    return false;
}
//-->

