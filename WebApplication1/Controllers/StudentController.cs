﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.ViewModels;
<<<<<<< HEAD
=======

>>>>>>> origin/master
namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {
<<<<<<< HEAD
=======

>>>>>>> origin/master
        public ActionResult Submissoin(FormCollection data)
        {
            var code = "#include <iostream>\n" +
                        "using namespace std; \n" +
                        "int main()\n" +
                        "{\n" +
                        "cout << \"Hello world\" << endl;\n" +
                        "cout << \"The output should contain two lines\" << endl;\n" +
                        "return 0;\n" +
                        "}";
<<<<<<< HEAD
=======

>>>>>>> origin/master
            var workingFolder = "C:\\Temp\\Mooshak2Code\\";
            //Finna út hvert nefnið á notandanum er sem loggaður er inn. Ef það er til mappa frá honum þá að nota hana annars að búa hana til með:
            //Directory.CreateDirectory;
            var cppFileName = "Hello.cpp";
            var exeFilePath = workingFolder + "Hello.exe";
<<<<<<< HEAD
            //Write the code to a file, such that the compiler
            //can find it:
            System.IO.File.WriteAllText(workingFolder + cppFileName, code);
=======

            //Write the code to a file, such that the compiler
            //can find it:
            System.IO.File.WriteAllText(workingFolder + cppFileName, code);

>>>>>>> origin/master
            //In this case, we use the C++ compiler (cl.exe) which ships
            //with Visual Studio. It is located in this folder:
            var compileFolder = "C:\\Program Files (x86)\\Microsoft Visual Studio 14.0\\VC\\bin\\";
            //There is a bit more to executing the compiler than
            //just calling cl.exe. In order for it to be able to know
            //where to find #include-d files (such as <iostream>),
            //we need to add certain folders to the PATH.
            // There is a .bat file which does that, and it is 
            //located in the same folder as cl.exe, so we need to execute
            //that .bat file first.
<<<<<<< HEAD
=======

>>>>>>> origin/master
            //Using this  approach means that:
            //  *the computer running out web application must have
            //   Visual Studio installed. This is an assumption we can make in thi project.
            //  *Hardcoding the path to the compiler is not an optimal
            //   solution. A better approach is to store the path in web.config, and access that 
            //   value using ConfigurationManager.AppSettings.
<<<<<<< HEAD
=======

>>>>>>> origin/master
            //Execute the compiler:
            Process compiler = new Process();
            compiler.StartInfo.FileName = "cmd.exe";
            compiler.StartInfo.WorkingDirectory = workingFolder;
            compiler.StartInfo.RedirectStandardInput = true;
            compiler.StartInfo.RedirectStandardOutput = true;
            compiler.StartInfo.UseShellExecute = false;
<<<<<<< HEAD
=======

>>>>>>> origin/master
            compiler.Start();
            compiler.StandardInput.WriteLine("\"" + compileFolder + "vcvars32.bat" + "\"");
            compiler.StandardInput.WriteLine("cl.exe /nologo /EHsc " + cppFileName);
            compiler.StandardInput.WriteLine("exit");
            string output = compiler.StandardOutput.ReadToEnd();
            compiler.WaitForExit();
            compiler.Close();
<<<<<<< HEAD
=======

>>>>>>> origin/master
            //Check if the compiler succeeded, and if it did,
            //we try to execute the code:
            if (System.IO.File.Exists(exeFilePath))
            {
                var processInfoExe = new ProcessStartInfo(exeFilePath, "");
                processInfoExe.UseShellExecute = false;
                processInfoExe.RedirectStandardOutput = true;
                processInfoExe.RedirectStandardError = true;
                processInfoExe.CreateNoWindow = true;
                using (var processExe = new Process())
                {
                    processExe.StartInfo = processInfoExe;
                    processExe.Start();
                    //In this example, we don't try to pass any input to the program,
                    //but that is of course also necessary. We would do that here, using 
                    //processExe.StandardInput.WritLine(), similar to above.
<<<<<<< HEAD
=======

>>>>>>> origin/master
                    //we then read the output of the program:
                    var lines = new List<string>();
                    while (!processExe.StandardOutput.EndOfStream)
                    {
                        lines.Add(processExe.StandardOutput.ReadLine());
                    }
<<<<<<< HEAD
=======

>>>>>>> origin/master
                    ViewBag.Output = lines;
                }
            }
            //Það vantar else hér!!
<<<<<<< HEAD
            //TODE: we might want to clean up after the process, there 
            //may be files we should delete etc.
            return View();
        }
        // GET: Student
        
    }
}
=======

            //TODE: we might want to clean up after the process, there 
            //may be files we should delete etc.

            return View();

        }

        // GET: Student
        
    }
}
>>>>>>> origin/master