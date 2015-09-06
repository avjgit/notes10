import os
def rename_files():
	files = os.listdir(r"C:\test")
	print(files)
	os.chdir(r"C:\test")
	for f in files:
		os.rename(f, f.translate(None, "0123456789"))

rename_files()