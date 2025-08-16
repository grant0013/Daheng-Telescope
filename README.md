Daheng Telescope Control
This application is a comprehensive astrophotography capture tool designed to control Daheng Imaging cameras using the GxIAPINET SDK. It has evolved from a basic camera viewer into a powerful utility with features tailored for capturing high-quality celestial images.

Core Functionality
Camera Connection: Automatically detects and connects to the first available Daheng Imaging camera.

Live Video Stream: Provides a real-time video feed from the connected camera for focusing and framing.

Acquisition Control: Full control over starting, stopping, and recording video sequences.

Astrophotography & Capture Features
Manual Exposure & Gain: Essential for astrophotography, this application provides full manual control over exposure time and gain.

Exposure is set in seconds for an intuitive, DSLR-like experience.

Input values are automatically validated and clamped to the camera's supported range to prevent errors.

RAW Image Capture: A dedicated button allows for capturing a single, unprocessed .raw frame, preserving maximum data quality for post-processing.

Video Sequence Recording: The "Record" button saves a sequence of frames as individual BMP images to a timestamped folder. This is the ideal format for use in stacking software like AutoStakkert! and RegiStax.

Custom Save Location: Users can select a custom folder for saving all captured raw images and video recordings.

Advanced Camera & Image Controls
Auto Modes: Buttons are available to toggle the camera's automatic exposure, gain, and white balance modes. When an auto mode is active, the corresponding manual controls become read-only and display the live values from the camera.

Full Resolution Control:

Pixel Format: A dropdown allows the selection of the camera's native sensor format (e.g., BayerRG8, Mono12) for uncompressed data capture.

Binning: A dropdown provides control over pixel binning (e.g., 1x1 for full resolution, 2x2 for increased sensitivity).

Live View Enhancement: To aid in focusing and framing on faint deep-sky objects, the application includes a suite of real-time image processing controls that only affect the live display, not the saved raw data:

Histogram Stretch: Sliders for Gamma, Contrast, and Brightness.

Manual Color Balance: Red, Green, and Blue sliders to provide precise control for neutralizing color casts, especially useful for cameras with their IR cut filter removed.

User Interface
Tabbed Layout: All camera controls are organized into a clean, multi-tabbed interface for easy navigation. The tabs are logically grouped into:

Camera: Core settings like Exposure, Gain, White Balance, Pixel Format, and Binning.

Live View: Real-time display adjustments.

Capture & Saving: Controls for recording, raw capture, and file locations.

Real-time Feedback: The UI provides constant feedback, such as changing button colors to indicate active states (e.g., "Record" turns red) and updating labels with live data.
