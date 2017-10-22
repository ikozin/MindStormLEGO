package src.app.ikozin.nxt.bluetooth;

import android.app.Activity;
import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.Window;
import android.widget.SeekBar;
import android.widget.TextView;
import android.widget.Toast;

public class BTNXTActivity extends Activity implements
		SeekBar.OnSeekBarChangeListener {

	// Message types sent from the BluetoothChatService Handler
	public static final int MESSAGE_STATE_CHANGE = 1;
	public static final int MESSAGE_READ = 2;
	public static final int MESSAGE_WRITE = 3;
	public static final int MESSAGE_DEVICE_NAME = 4;
	public static final int MESSAGE_TOAST = 5;

	// Key names received from the BluetoothChatService Handler
	public static final String DEVICE_NAME = "device_name";
	public static final String TOAST = "toast";

	// Intent request codes
	private static final int REQUEST_CONNECT_DEVICE = 1;
	private static final int REQUEST_ENABLE_BT = 2;

	// Layout Views
	private TextView mTitle;
	private TextView mStatus;

	private int mPower = 50;
	private int mCommand = 5;

	// Name of the connected device
	private String mConnectedDeviceName = null;
	// Array adapter for the conversation thread
	// private ArrayAdapter<String> mConversationArrayAdapter;
	// String buffer for outgoing messages
	// private StringBuffer mOutStringBuffer;
	// Local Bluetooth adapter
	private BluetoothAdapter mBluetoothAdapter = null;
	// Member object for the chat services
	private NxtBluetoothService mChatService = null;

	/** Called when the activity is first created. */
	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);

		// Set up the window layout
		requestWindowFeature(Window.FEATURE_CUSTOM_TITLE);
		setContentView(R.layout.main);
		getWindow().setFeatureInt(Window.FEATURE_CUSTOM_TITLE,
				R.layout.custom_title);

		// Set up the custom title
		mTitle = (TextView) findViewById(R.id.title_left_text);
		mTitle.setText(R.string.app_name);
		mTitle = (TextView) findViewById(R.id.title_right_text);

		final SeekBar seekBar = (SeekBar) this.findViewById(R.id.seekPower);
		seekBar.setProgress(mPower);
		seekBar.setOnSeekBarChangeListener(this);

		mStatus = (TextView) this.findViewById(R.id.textStatus);
		mStatus.setText("");

		// Get local Bluetooth adapter
		mBluetoothAdapter = BluetoothAdapter.getDefaultAdapter();

		// If the adapter is null, then Bluetooth is not supported
		if (mBluetoothAdapter == null) {
			Toast.makeText(this, "Bluetooth is not available",
					Toast.LENGTH_LONG).show();
			finish();
			return;
		}
	}

	@Override
	public void onStart() {
		super.onStart();

		// If BT is not on, request that it be enabled.
		// setupChat() will then be called during onActivityResult
		if (!mBluetoothAdapter.isEnabled()) {
			Intent enableIntent = new Intent(
					BluetoothAdapter.ACTION_REQUEST_ENABLE);
			startActivityForResult(enableIntent, REQUEST_ENABLE_BT);
			// Otherwise, setup the chat session
		} else {
			if (mChatService == null)
				setupChat();
		}
	}

	@Override
	public synchronized void onResume() {
		super.onResume();

		// Performing this check in onResume() covers the case in which BT was
		// not enabled during onStart(), so we were paused to enable it...
		// onResume() will be called when ACTION_REQUEST_ENABLE activity
		// returns.
		if (mChatService != null) {
			// Only if the state is STATE_NONE, do we know that we haven't
			// started already
			if (mChatService.getState() == NxtBluetoothService.STATE_NONE) {
				// Start the Bluetooth chat services
				mChatService.start();
			}
		}
	}

	private void setupChat() {
		/*
		 * // Initialize the array adapter for the conversation thread
		 * mConversationArrayAdapter = new ArrayAdapter<String>(this,
		 * R.layout.message); mConversationView = (ListView)
		 * findViewById(R.id.in);
		 * mConversationView.setAdapter(mConversationArrayAdapter);
		 * 
		 * // Initialize the compose field with a listener for the return key
		 * mOutEditText = (EditText) findViewById(R.id.edit_text_out);
		 * mOutEditText.setOnEditorActionListener(mWriteListener);
		 * 
		 * // Initialize the send button with a listener that for click events
		 * mSendButton = (Button) findViewById(R.id.button_send);
		 * mSendButton.setOnClickListener(new OnClickListener() { public void
		 * onClick(View v) { // Send a message using content of the edit text
		 * widget TextView view = (TextView) findViewById(R.id.edit_text_out);
		 * String message = view.getText().toString(); sendMessage(message); }
		 * });
		 */
		// Initialize the BluetoothChatService to perform bluetooth connections
		mChatService = new NxtBluetoothService(this, mHandler);

		// Initialize the buffer for outgoing messages
		// mOutStringBuffer = new StringBuffer("");
	}

	@Override
	public synchronized void onPause() {
		super.onPause();
	}

	@Override
	public void onStop() {
		super.onStop();
	}

	@Override
	public void onDestroy() {
		super.onDestroy();
		// Stop the Bluetooth chat services
		if (mChatService != null)
			mChatService.stop();
	}

	// private void ensureDiscoverable() {
	// if (mBluetoothAdapter.getScanMode() !=
	// BluetoothAdapter.SCAN_MODE_CONNECTABLE_DISCOVERABLE) {
	// Intent discoverableIntent = new Intent(
	// BluetoothAdapter.ACTION_REQUEST_DISCOVERABLE);
	// discoverableIntent.putExtra(
	// BluetoothAdapter.EXTRA_DISCOVERABLE_DURATION, 300);
	// startActivity(discoverableIntent);
	// }
	// }

//	/**
//	 * Sends a message.
//	 * 
//	 * @param message
//	 *            A string of text to send.
//	 */
//	private void sendMessage(String message) {
//		// Check that we're actually connected before trying anything
//		if (mChatService.getState() != NxtBluetoothService.STATE_CONNECTED) {
//			Toast.makeText(this, R.string.not_connected, Toast.LENGTH_SHORT)
//					.show();
//			return;
//		}
//
//		// Check that there's actually something to send
//		if (message.length() > 0) {
//			// Get the message bytes and tell the BluetoothChatService to write
//			byte[] send = message.getBytes();
//			mChatService.write(send);
//
//			// Reset out string buffer to zero and clear the edit text field
//			// mOutStringBuffer.setLength(0);
//			// mOutEditText.setText(mOutStringBuffer);
//		}
//	}

	// // The action listener for the EditText widget, to listen for the return
	// key
	// private TextView.OnEditorActionListener mWriteListener = new
	// TextView.OnEditorActionListener() {
	// public boolean onEditorAction(TextView view, int actionId,
	// KeyEvent event) {
	// // If the action is a key-up event on the return key, send the
	// // message
	// if (actionId == EditorInfo.IME_NULL
	// && event.getAction() == KeyEvent.ACTION_UP) {
	// String message = view.getText().toString();
	// sendMessage(message);
	// }
	// return true;
	// }
	// };

	// The Handler that gets information back from the BluetoothChatService
	private final Handler mHandler = new Handler() {
		@Override
		public void handleMessage(Message msg) {
			switch (msg.what) {
			case MESSAGE_STATE_CHANGE:
				switch (msg.arg1) {
				case NxtBluetoothService.STATE_CONNECTED:
					mTitle.setText(R.string.title_connected_to);
					mTitle.append(mConnectedDeviceName);
					// mConversationArrayAdapter.clear();
					break;
				case NxtBluetoothService.STATE_CONNECTING:
					mTitle.setText(R.string.title_connecting);
					break;
				case NxtBluetoothService.STATE_LISTEN:
				case NxtBluetoothService.STATE_NONE:
					mTitle.setText(R.string.title_not_connected);
					break;
				}
				break;
			case MESSAGE_WRITE:
				// byte[] writeBuf = (byte[]) msg.obj;
				// // construct a string from the buffer
				// String writeMessage = new String(writeBuf);
				// mConversationArrayAdapter.add("Me:  " + writeMessage);
				break;
			case MESSAGE_READ:
				byte[] readBuf = (byte[]) msg.obj;
				// construct a string from the valid bytes in the buffer
				String readMessage = new String(readBuf, 0, msg.arg1);
				// mConversationArrayAdapter.add(mConnectedDeviceName + ":  " +
				// readMessage);
				Toast.makeText(getApplicationContext(),
						"Recieved message: " + readMessage, Toast.LENGTH_SHORT)
						.show();
				break;
			case MESSAGE_DEVICE_NAME:
				// save the connected device's name
				mConnectedDeviceName = msg.getData().getString(DEVICE_NAME);
				Toast.makeText(getApplicationContext(),
						"Connected to " + mConnectedDeviceName,
						Toast.LENGTH_SHORT).show();
				break;
			case MESSAGE_TOAST:
				Toast.makeText(getApplicationContext(),
						msg.getData().getString(TOAST), Toast.LENGTH_SHORT)
						.show();
				break;
			}
		}
	};

	public void onActivityResult(int requestCode, int resultCode, Intent data) {
		switch (requestCode) {
		case REQUEST_CONNECT_DEVICE:
			// When DeviceListActivity returns with a device to connect
			if (resultCode == Activity.RESULT_OK) {
				// Get the device MAC address
				String address = data.getExtras().getString(
						DeviceListActivity.EXTRA_DEVICE_ADDRESS);
				// Get the BLuetoothDevice object
				BluetoothDevice device = mBluetoothAdapter
						.getRemoteDevice(address);
				// Attempt to connect to the device
				mChatService.connect(device);
			}
			break;
		case REQUEST_ENABLE_BT:
			// When the request to enable Bluetooth returns
			if (resultCode == Activity.RESULT_OK) {
				// Bluetooth is now enabled, so set up a chat session
				setupChat();
			} else {
				// User did not enable Bluetooth or an error occured
				Toast.makeText(this, R.string.bt_not_enabled_leaving,
						Toast.LENGTH_SHORT).show();
				finish();
			}
		}
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		MenuInflater inflater = getMenuInflater();
		inflater.inflate(R.menu.option_menu, menu);
		return true;
	}

	@Override
	public boolean onOptionsItemSelected(MenuItem item) {
		switch (item.getItemId()) {
		case R.id.scan:
			// Launch the DeviceListActivity to see devices and do scan
			Intent serverIntent = new Intent(this, DeviceListActivity.class);
			startActivityForResult(serverIntent, REQUEST_CONNECT_DEVICE);
			return true;
			// case R.id.discoverable:
			// // Ensure this device is discoverable by others
			// ensureDiscoverable();
			// return true;
		}
		return false;
	}

	public void onClickButtonCommand(View v) {
		String mText = "";
		switch (v.getId()) {
		case R.id.button0:
			mCommand = 0;
			mText = "";
			break;
		case R.id.button1:
			mCommand = 1;
			mText = String.format("Command:%d, Power:%d", mCommand, mPower);
			break;
		case R.id.button2:
			mCommand = 2;
			mText = String.format("Command:%d, Power:%d", mCommand, mPower);
			break;
		case R.id.button3:
			mCommand = 3;
			mText = String.format("Command:%d, Power:%d", mCommand, mPower);
			break;
		case R.id.button4:
			mCommand = 4;
			mText = String.format("Command:%d, Power:%d", mCommand, mPower);
			break;
		case R.id.button5:
			mCommand = 5;
			mText = String.format("Command:%d, Power:%d", mCommand, mPower);
			break;
		case R.id.button6:
			mCommand = 6;
			mText = String.format("Command:%d, Power:%d", mCommand, mPower);
			break;
		case R.id.button7:
			mCommand = 7;
			mText = String.format("Command:%d, Power:%d", mCommand, mPower);
			break;
		case R.id.button8:
			mCommand = 8;
			mText = String.format("Command:%d, Power:%d", mCommand, mPower);
			break;
		case R.id.button9:
			mCommand = 9;
			mText = String.format("Command:%d, Power:%d", mCommand, mPower);
			break;
		default:
			mCommand = 5;
			mText = "";
			break;
		}
		sendCommand(mCommand);
		sendPower(mPower);
		mStatus.setText(mText);
	}

	public void sendCommand(float cmd) {
		int bits = Float.floatToIntBits(cmd);
		byte[] data = new byte[9];
		data[0x00000000] = (byte) 0x80;
		data[0x00000001] = (byte) 0x09;
		data[0x00000002] = (byte) 0x00;
		data[0x00000003] = (byte) 0x05;
		data[0x00000004] = (byte) ((bits >> 0) & 0xFF);
		data[0x00000005] = (byte) ((bits >> 8) & 0xFF);
		data[0x00000006] = (byte) ((bits >> 16) & 0xFF);
		data[0x00000007] = (byte) ((bits >> 24) & 0xFF);
		data[0x00000008] = (byte) 0x00; // final byte
		mChatService.write(data);
	}

	public void sendPower(float power) {
		int bits = Float.floatToIntBits(power);
		byte[] data = new byte[9];
		data[0x00000000] = (byte) 0x80;
		data[0x00000001] = (byte) 0x09;
		data[0x00000002] = (byte) 0x01;
		data[0x00000003] = (byte) 0x05;
		data[0x00000004] = (byte) ((bits >> 0) & 0xFF);
		data[0x00000005] = (byte) ((bits >> 8) & 0xFF);
		data[0x00000006] = (byte) ((bits >> 16) & 0xFF);
		data[0x00000007] = (byte) ((bits >> 24) & 0xFF);
		data[0x00000008] = (byte) 0x00; // final byte
		mChatService.write(data);
	}

	@Override
	public void onProgressChanged(SeekBar seekBar, int progress,
			boolean fromUser) {
		mPower = progress;
		sendPower(mPower);
		mStatus.setText(String.format("Power:%d", mPower));
	}

	@Override
	public void onStartTrackingTouch(SeekBar seekBar) {
	}

	@Override
	public void onStopTrackingTouch(SeekBar seek�ar) {
	}
}