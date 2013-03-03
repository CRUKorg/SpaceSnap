import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;

public class Analyse {

	/**
	 * @param args
	 * @throws IOException 
	 */
	public static void main(String[] args) throws IOException {
		String path = "data/";

		String files;
		File folder = new File(path);
		File[] listOfFiles = folder.listFiles();

		String plotterPath = "plotter";
		
		BufferedWriter bw = new BufferedWriter(new FileWriter(plotterPath));
		bw.write("plot ");
		
		
		int numFiles = 0;
		
		for (int i = 0; i < listOfFiles.length; i++) {
			if (listOfFiles[i].isFile()) {
				files = listOfFiles[i].getPath();
				if (numFiles > 0) {
					bw.write(", ");
				}
				bw.write("\"" + files + "\" using 1:2 with lines");
				numFiles++;
			}
		}
		
		bw.close();
	}

}

