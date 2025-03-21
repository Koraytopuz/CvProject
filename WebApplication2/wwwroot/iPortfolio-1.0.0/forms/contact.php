<?php
// Yalnızca POST isteklerini işleyin.
if ($_SERVER["REQUEST_METHOD"] == "POST") {
    // Form alanlarını al ve boşlukları temizle.
    $name = strip_tags(trim($_POST["name"]));
    $name = str_replace(array("\r", "\n"), array(" ", " "), $name);
    $email = filter_var(trim($_POST["email"]), FILTER_SANITIZE_EMAIL);
    $message = trim($_POST["message"]);

    // Gönderilen verileri kontrol edin.
    if (empty($name) OR empty($message) OR !filter_var($email, FILTER_VALIDATE_EMAIL)) {
        // 400 (bad request) hata kodu ve çıkış.
        http_response_code(400);
        echo "Lütfen formu doğru bir şekilde doldurun ve tekrar deneyin.";
        exit;
    }

   
    $recipient = "krytopuz@gmail.com";
    $subject = "Mesaj: $name tarafından gönderildi";

    // E-posta içeriği.
    $email_content = "Adı: $name\n";
    $email_content .= "E-posta: $email\n\n";
    $email_content .= "Mesaj:\n$message\n";

    // E-posta başlıkları.
    $email_headers = "From: $name <$email>";

    // E-posta gönder.
    if (mail($recipient, $subject, $email_content, $email_headers)) {
        // 200 (başarılı) yanıt kodu.
        http_response_code(200);
        echo "Teşekkürler! Mesajınız başarıyla gönderildi.";
    } else {
        // 500 (iç sunucu hatası) yanıt kodu.
        http_response_code(500);
        echo "Üzgünüz, mesajınızı gönderirken bir hata oluştu.";
    }

} else {
    // POST olmayan istekler için 403 (yasak) yanıt kodu.
    http_response_code(403);
    echo "Formu göndermede bir sorun oluştu, lütfen tekrar deneyin.";
}
?> 
