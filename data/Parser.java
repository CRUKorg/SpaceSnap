import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.util.Iterator;
import java.util.Map.Entry;
import java.util.TreeMap;

public class Parser {

	public static void main(String[] args) throws NumberFormatException,
			IOException {
		String filePath = "";
		String outputPath = "";
		switch (args.length) {
		case 0:
			System.out.println("No input.");
			System.exit(0);
		case 1:
			filePath = args[0];
			outputPath = filePath + "x";
			break;
		case 2:
			filePath = args[0];
			outputPath = args[1];
			break;
		default:
			System.out.println("Too much input.");
			System.exit(0);
		}
		/* Read in file. */
		BufferedReader br = new BufferedReader(new FileReader(filePath));
		System.out.println("File opened.");
		String line = "";
		int i = 0, sum = 0, avg = 0, next = 0, prev = 0, begin = 0;
		TreeMap<Integer, Float> ht = new TreeMap<Integer, Float>();
		System.out.println("Sorting.");
		/* Go through the lines. Skip the first line. */
		br.readLine();
		while ((line = br.readLine()) != null) {
			String[] arr = line.split("\\s+");
			/* Get x and normalize against beginning. */
			if (i == 0) {
				//begin = Integer.parseInt(arr[1]);
				i++;
			}
			int x = Integer.parseInt(arr[1]) - begin;
			float y = Float.parseFloat(arr[2]);
			/* Ordered insert into tree. */
			ht.put(x, y);
		}
		br.close();
		System.out.println("Sorted.\nNormalising.");
		/* Calculate average interval in x axis. */
		i = 0;
		Iterator<Entry<Integer, Float>> it = ht.entrySet().iterator();
		while (it.hasNext()) {
			Entry<Integer, Float> e = it.next();
			if (i == 0) {
				prev = e.getKey().intValue();
				begin = prev;
			}
			next = e.getKey().intValue();
			sum += next - prev;
			prev = next;
			i++;
		}
		System.out.println("Normalised.");
		avg = (sum / i);
		System.out.println("Lines: " + i);
		System.out.println("Average Interval: " + avg);
		/* File writing/output. */
		BufferedWriter wr = new BufferedWriter(new FileWriter(outputPath));
		it = ht.entrySet().iterator();
		System.out.println("Outputing to file: " + outputPath);
		/* Go through the tree ordered and write values to file. */
		while (it.hasNext()) {
			Entry<Integer, Float> e = it.next();
			int x = e.getKey().intValue();
			x -= begin;
			float y = e.getValue().floatValue();
			if (x > 0) {
				x = x / avg;
			}
			wr.write(x + "\t" + y + "\n");
		}
		wr.close();
		System.out.println("Done");
	}

}

