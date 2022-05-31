# Process Protection
WARNING! Requires Administrator Rights
# Disclaimer
TO BE USED FOR EDUCATIONAL PURPOSES ONLY

The use of the Process Protection is COMPLETE RESPONSIBILITY of the END-USER. Developers assume NO liability and are NOT responsible for any misuse or damage caused by this program.

"DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE."
# Example
````
using System;
using System.Diagnostics;

class Program
{
	static void Main()
	{
		ProcessProtection.ProtectProcess(); //Protect current process
		while (true)
		{
			Console.WriteLine("Enter name of process you want to protect without .exe!");
			string prcname = Console.ReadLine();
			if (pcrname != "")
			{
				ProcessProtection.ProtectProcess(Process.GetProcessesByName(pcrname)[0]);
				Console.WriteLine("Protected!");
			}
			Console.WriteLine("Enter name of process you want to unprotect without .exe!");
			prcname = Console.ReadLine();
			if (pcrname != "")
			{
				ProcessProtection.UnprotectProcess(Process.GetProcessesByName(pcrname)[0]);
				Console.WriteLine("Unprotected!");
			}
		}
		
	}
}
````
