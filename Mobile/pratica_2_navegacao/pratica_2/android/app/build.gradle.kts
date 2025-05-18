plugins {
    id("com.android.application")
    id("kotlin-android")
    // O plugin do Flutter deve ser aplicado após os plugins Android e Kotlin.
    id("dev.flutter.flutter-gradle-plugin")
}

android {
    namespace = "com.example.flutter_navigation"
    compileSdk = flutter.compileSdkVersion
    ndkVersion = flutter.ndkVersion

    compileOptions {
        sourceCompatibility = JavaVersion.VERSION_11
        targetCompatibility = JavaVersion.VERSION_11
    }

    kotlinOptions {
        jvmTarget = JavaVersion.VERSION_11.toString()
    }

    defaultConfig {
        // ID único do aplicativo
        applicationId = "com.example.flutter_navigation"
        // Configurações de SDK
        minSdk = flutter.minSdkVersion
        targetSdk = flutter.targetSdkVersion
        versionCode = flutter.versionCode
        versionName = flutter.versionName
    }

    buildTypes {
        release {
            // Configuração de assinatura para o build de release
            signingConfig = signingConfigs.getByName("debug")
            // Habilitar minificação para reduzir o tamanho do APK
            isMinifyEnabled = true
            proguardFiles(
                getDefaultProguardFile("proguard-android-optimize.txt"),
                "proguard-rules.pro"
            )
        }
    }

    // Habilitar cache de builds para melhorar o desempenho
    buildFeatures {
        viewBinding = true
    }
}

flutter {
    source = "../.."
}