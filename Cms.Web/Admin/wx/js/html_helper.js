$(function(a) {
    a.htmlEncode = function(b) {
        return b.replace(/&/g, "&amp;").replace(/ /g, "&nbsp;").replace(/</g, "&lt;").replace(/>/g, "&gt;").replace(/\n/g, "<br />").replace(/"/g, "&quot;").replace(/'/g, "&#39;")
    };
    a.htmlDecode = function(b) {
        return b.replace(/&#39;/g, "'").replace(/<[Bb][Rr]\s*(\/)?\s*>/g, "\n").replace(/&nbsp;/g, " ").replace(/&lt;/g, "<").replace(/&gt;/g, ">").replace(/&quot;/g, '"').replace(/&amp;/g, "&")
    };
    a.htmlFilter = function(b) {
        return b == null ? "": b.replace(/<\s*\/?[^>]*\s*>/g, "").replace(/"/g, "")
    }
} (jQuery));