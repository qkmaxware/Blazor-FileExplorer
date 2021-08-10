using System.Linq;
using System.Text.RegularExpressions;

namespace Qkmaxware.Blazor.FileExplorer.Data {

public class FilenameFilter {
    public string Name {get; private set;}
    public string Hint {get; private set;}
    private Regex pattern;
    
    public FilenameFilter(string name, string hint, Regex pattern) {
        this.Name = name;
        this.Hint = hint;
        this.pattern = pattern;
    }
    public static FilenameFilter Any() {
        return new FilenameFilter("All Files", ".*", new Regex(@".*"));
    }
    public static FilenameFilter Extension(string name, params string[] exts) {
        var combined = string.Join('|', exts.Select(ext => Regex.Escape(ext)));
        var hint = string.Join(',', exts.Select(ext => "." + ext));
        return new FilenameFilter(name, hint, new Regex($"\\.({combined})$"));
    }

    public bool Matches(string filename) {
        return pattern != null ? pattern.IsMatch(filename) : false;
    }
}
    
}