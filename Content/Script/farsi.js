// Original idea is from:      
// http://cvs.sourceforge.net/cgi-bin/viewcvs.cgi/farsitools/#dirlist and      
// http://cvs.sourceforge.net/cgi-bin/viewcvs.cgi/farsitools/php/date/scripts/
// And the idea for swicthing between languages comes from 
// http://www.shamlou.org/forum/post.php?f=2
// Modified to comply with Farsi Unicode standard by CyrusTheGreat, CyrusArmy@yahoo.com , Modify by Navid (http://weblog.mojde.com) for language button
      

// Farsi keyboard map based on Iran Popular Keyboard Layout

var farsikey = [	// Farsi keyboard map based on Iran Popular Keyboard Layout      
	0x0020, 0x0021, 0x061B, 0x066B, 0x00A4, 0x066A, 0x060C, 0x06AF, 
	0x0029, 0x0028, 0x002A, 0x002B, 0x0648, 0x002D, 0x002E, 0x002F,      
	0x06F0, 0x06F1, 0x06F2, 0x06F3, 0x06F4, 0x06F5, 0x06F6, 0x06F7,      
	0x06F8, 0x06F9, 0x003A, 0x06A9, 0x003E, 0x003D, 0x003C, 0x061F,      
	0x066C, 0x0624, 0x200C, 0x0698, 0X064a, 0x064D, 0x0625, 0x0623,      
	0x0622, 0x0651, 0x0629, 0x00BB, 0x00AB, 0x0621, 0x004E, 0x005D,      
	0x005B, 0x0652, 0x064B, 0x0626, 0x064F, 0x064E, 0x0056, 0x064C,            
	0x0058, 0x0650, 0x0643, 0x062C, 0x0698, 0x0686, 0x00D7, 0x0640,
	0x067E, 0x0634, 0x0630, 0x0632, 0X06cc, 0x062B, 0x0628, 0x0644,            
	0x0627, 0x0647, 0x062A, 0x0646, 0x0645, 0x0626, 0x062F, 0x062E,            
	0x062D, 0x0636, 0x0642, 0x0633, 0x0641, 0x0639, 0x0631, 0x0635,            
	0x0637, 0x063A, 0x0638, 0x007D, 0x007C, 0x007B, 0x007E            
];            
            

function FKeyPress() {
   var key = window.event.keyCode;
   if (key < 0x0020 || key >= 0x00FF) 
      return;
   if (language=='f') {
      var ValChar=String.fromCharCode(key);
      var validate="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ[];,'`\\"
      var el = event.srcElement; 

      if (validate.indexOf(ValChar) != -1 ) // Detect persian letter
      if (el.value.charCodeAt(el.value.length-1) == 0x06cc)  // Replace persian ye if needed
      {
         el.value = el.value.slice(0, -1);
         el.value += String.fromCharCode(0x064a); // Use arabic ye
      }
      if (key == 0x0020 && window.event.shiftKey)
         window.event.keyCode = 0x200C;
      else 
	 window.event.keyCode = farsikey[key - 0x0020];
   }
  return true;
}


function Changelang(whatimage,what,imageEN,imageFA) {
            if(language == 'f') {
                what.onkeypress=null;
                what.style.textAlign = "right";
		    what.style.direction = "rtl";
                language='e';
                whatimage.src=imageEN;
                whatimage.title='Change language to persian' 
            }
            else {
                what.onkeypress=FKeyPress;
                what.style.textAlign = "right";
		    what.style.direction = "rtl";
                language='f';
               whatimage.src=imageFA;
                whatimage.title='Change language to english' 
            }
            what.focus();
        }
var language='f';