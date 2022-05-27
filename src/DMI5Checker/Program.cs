using DMISharp;
using System;
using System.Collections.Generic;
using System.IO;

namespace DMI5Checker {
    internal class Program {
        static void Main(string[] args) {
			string[] dmi_files = Directory.GetFiles(args[0], "*.*", SearchOption.AllDirectories);

			List<string> failed_dmis = new List<string>();

			foreach (string current_dmi_path in dmi_files) {
				// Skip non DMIs
				if(!current_dmi_path.EndsWith(".dmi")) {
					continue;
				}

				// Load it in
				try {
					using (DMIFile current_dmi = new DMIFile(current_dmi_path)) {
						// If too new, fail
						if (current_dmi.Metadata.Version > 4) {
							failed_dmis.Add(current_dmi_path);
						}
					}
				} catch {
					// If not a DMI, fail
					failed_dmis.Add(current_dmi_path);
				}

			}

			if (failed_dmis.Count > 0) {
				Console.WriteLine("The following DMIs are too new or otherwise invalid:");
				foreach(string failure in failed_dmis) {
					Console.WriteLine($"- {failure}");
				}
				Environment.Exit(1);
			}
			Environment.Exit(0);
        }
    }
}
